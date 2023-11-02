using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.Application.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationCommand _organizationCommand;

    public OrganizationService(IOrganizationCommand organizationCommand)
    {
        _organizationCommand = organizationCommand;
    }
    
    public async Task<long> CreateAsync(Organization organization)
    {
        return await _organizationCommand.CreateAsync(organization);
    }

    public async Task DeleteAsync(Organization organization)
    {
        await _organizationCommand.DeleteAsync(organization);
    }

    public async Task UpdateAsync(Organization organization)
    {
        await _organizationCommand.UpdateAsync(organization);
    }
}