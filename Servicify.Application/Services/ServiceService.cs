using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.Application.Services;

public class ServiceService : IServiceService
{
    private readonly IAvailableTimeService _availableTimeService;
    private readonly IServiceCommand _serviceCommand;

    public ServiceService(IServiceCommand serviceCommand, IAvailableTimeService availableTimeService)
    {
        _serviceCommand = serviceCommand;
        _availableTimeService = availableTimeService;
    }

    public async Task<long> CreateAsync(ServiceCreateRequest serviceCreateRequest)
    {
        var service = new Service(
            serviceCreateRequest.Name,
            serviceCreateRequest.Description,
            serviceCreateRequest.OrganizationId,
            null);
        var serviceId = await _serviceCommand.CreateAsync(service);
        foreach (var date in serviceCreateRequest.AvailableTime)
        {
            var availableTime = new AvailableTime(serviceId, date);
            await _availableTimeService.CreateAsync(availableTime);
        }

        return serviceId;
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