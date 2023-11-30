using Servicify.Application.Dtos;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Application.Services;

public class ServiceService : IServiceService
{
    private readonly IAvailableTimeService _availableTimeService;
    private readonly IClientQuery _clientQuery;
    private readonly IServiceCommand _serviceCommand;
    private readonly IServiceQuery _serviceQuery;

    public ServiceService(IServiceCommand serviceCommand, IAvailableTimeService availableTimeService, IClientQuery clientQuery, IServiceQuery serviceQuery)
    {
        _serviceCommand = serviceCommand;
        _availableTimeService = availableTimeService;
        _clientQuery = clientQuery;
        _serviceQuery = serviceQuery;
    }

    public async Task<List<ServiceDto>> GetAllByOrganizationId(long orgnizationId)
    {
        var services = await _serviceQuery.GetAllByOrganizationIdAsync(orgnizationId);
        return services.Select(x => new ServiceDto()
        {
            Id = x.Id,
            Name = x.Name, 
            Description = x.Description, 
            AvailableTimes = x.AvailableTimes.Select(y => new AvailableTimeDto() {Date = y.Date, Id = y.Id}).ToList()
        }).ToList();
    }

    public async Task<List<ServiceAllDto>> GetAllAsync()
    {
        var services = await _serviceQuery.GetAllAsync();
        return services.Select(x => new ServiceAllDto() { Id = x.Id, Name = x.Name, Cost = x.Cost, OrganizationName = x.Organization.Name }).ToList();
    }

    public async Task<long> CreateAsync(ServiceCreateRequest serviceCreateRequest)
    {
        var service = new Service(
            serviceCreateRequest.Name,
            serviceCreateRequest.Description,
            serviceCreateRequest.Cost,
            serviceCreateRequest.OrganizationId,
            null);
        var serviceId = await _serviceCommand.CreateAsync(service);
        foreach (var date in serviceCreateRequest.AvailableTime)
        {
            DateTime utcDateTime = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            var availableTime = new AvailableTime(serviceId, utcDateTime);
            await _availableTimeService.CreateAsync(availableTime);
            service.AvailableTimes.Add(availableTime);
        }
        await _serviceCommand.UpdateAsync(service);

        return serviceId;
    }

    public async Task Subscribe(ServiceSubscribeRequest serviceSubscribeRequest)
    {
        var service = await _serviceQuery.FindByIdAsync(serviceSubscribeRequest.ServiceId);
        var client = await _clientQuery.FindByIdAsync(serviceSubscribeRequest.ClientId);
        client.Subscriptions.Add(service);
        service.Subscribers.Add(client);
        await _serviceCommand.UpdateAsync(service);
    }

    public async Task DeleteAsync(Service service)
    {
        await _serviceCommand.DeleteAsync(service);
    }

    public async Task UpdateAsync(Service service)
    {
        await _serviceCommand.UpdateAsync(service);
    }
}