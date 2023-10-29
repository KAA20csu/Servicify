using Servicify.Core;

namespace Servicify.DataAccess.Commands.Contracts;

public interface IClientCommand
{
    public Task<long> CreateAsync(Client client);
    public Task DeleteAsync(Client client);
    public Task UpdateAsync(Client client);
}