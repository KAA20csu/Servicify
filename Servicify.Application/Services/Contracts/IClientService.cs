using Servicify.Core;

namespace Servicify.Application.Services.Contracts;

public interface IClientService
{
    public Task<long> CreateAsync(Client client);
    public Task DeleteAsync(Client client);
    public Task UpdateAsync(Client client);
}