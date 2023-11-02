using Servicify.Core;

namespace Servicify.Application.Services.Contracts;

public interface IServiceService
{
    public Task<long> CreateAsync(Service service);
    public Task DeleteAsync(Service service);
    public Task UpdateAsync(Service service);
}