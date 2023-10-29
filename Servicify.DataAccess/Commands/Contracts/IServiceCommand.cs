using Servicify.Core;

namespace Servicify.DataAccess.Commands.Contracts;

public interface IServiceCommand
{
    public Task<long> CreateAsync(Service service);
    public Task DeleteAsync(Service service);
    public Task UpdateAsync(Service service);
}