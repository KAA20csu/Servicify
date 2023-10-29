using Servicify.Core;

namespace Servicify.DataAccess.Queries.Contracts;

public interface IOrganizationQuery
{
    public Task<Organization> FindByIdAsync(long id);
    public Task<Organization> FindByNameAsync(string name);
}