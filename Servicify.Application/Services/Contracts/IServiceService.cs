using Servicify.Core;
using Servicify.Requests;

namespace Servicify.Application.Services.Contracts;

public interface IServiceService
{
    public Task<long> CreateAsync(ServiceCreateRequest serviceCreateRequest);
    public Task DeleteAsync(Service service);
    public Task UpdateAsync(Service service);
}