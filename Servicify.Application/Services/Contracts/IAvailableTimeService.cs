using Servicify.Core;

namespace Servicify.Application.Services.Contracts;

public interface IAvailableTimeService
{
    public Task<long> CreateAsync(AvailableTime availableTime);
    public Task DeleteAsync(AvailableTime availableTime);
    public Task UpdateAsync(AvailableTime availableTime);
}