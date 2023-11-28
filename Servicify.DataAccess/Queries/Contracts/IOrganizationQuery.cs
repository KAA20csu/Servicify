using Servicify.Core;

namespace Servicify.DataAccess.Queries.Contracts;

public interface IOrganizationQuery
{
    public Task<Organization> FindByIdAsync(string id);
    public Task<Organization> FindByNameAsync(string name);
    Task<List<Organization>> GetAllAsync();
}