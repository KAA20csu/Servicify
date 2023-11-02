using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.Application.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceCommand _serviceCommand;

    public ServiceService(IServiceCommand serviceCommand)
    {
        _serviceCommand = serviceCommand;
    }
    
    public async Task<long> CreateAsync(Service service)
    {
        return await _serviceCommand.CreateAsync(service);
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