using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.Application.Services;

public class AvailableTimeService : IAvailableTimeService
{
    private readonly IAvailableTimeCommand _availableTimeCommand;

    public AvailableTimeService(IAvailableTimeCommand availableTimeCommand)
    {
        _availableTimeCommand = availableTimeCommand;
    }

    public async Task<long> CreateAsync(AvailableTime availableTime)
    {
        return await _availableTimeCommand.CreateAsync(availableTime);
    }

    public async Task DeleteAsync(AvailableTime availableTime)
    {
        await _availableTimeCommand.DeleteAsync(availableTime);
    }

    public async Task UpdateAsync(AvailableTime availableTime)
    {
        await _availableTimeCommand.UpdateAsync(availableTime);
    }
}