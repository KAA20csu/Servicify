using Servicify.Core;

namespace Servicify.Application.Services.Contracts;

public interface IOrganizationService
{
    public Task<long> CreateAsync(Organization organization);
    public Task DeleteAsync(Organization organization);
    public Task UpdateAsync(Organization organization);
}