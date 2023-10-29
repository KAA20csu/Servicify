using Servicify.Core;

namespace Servicify.DataAccess.Queries.Contracts;

public interface IClientQuery
{
    public Task<Client> FindByIdAsync(long id);
    public Task<Client> FindByNameAsync(string firstName, string lastName);
}