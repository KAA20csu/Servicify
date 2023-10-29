using Servicify.Core;

namespace Servicify.DataAccess.Commands.Contracts;

public interface IAvailableTimeCommand
{
    public Task<long> CreateAsync(AvailableTime availableTime);
    public Task DeleteAsync(AvailableTime availableTime);
    public Task UpdateAsync(AvailableTime availableTime);
}