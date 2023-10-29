using Servicify.Core;

namespace Servicify.DataAccess.Commands.Contracts;

public interface IOrganizationCommand
{
    public Task<long> CreateAsync(Organization organization);
    public Task DeleteAsync(Organization organization);
    public Task UpdateAsync(Organization organization);
}