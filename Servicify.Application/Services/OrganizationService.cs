using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Application.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationCommand _organizationCommand;
    private readonly IOrganizationQuery _organizationQuery;

    public OrganizationService(IOrganizationCommand organizationCommand, IOrganizationQuery organizationQuery)
    {
        _organizationCommand = organizationCommand;
        _organizationQuery = organizationQuery;
    }

    public async Task<long> CreateAsync(Organization organization)
    {
        return await _organizationCommand.CreateAsync(organization);
    }

    public async Task DeleteAsync(Organization organization)
    {
        await _organizationCommand.DeleteAsync(organization);
    }

    public async Task UpdateAsync(EditOrganizationRequest organizationRequest)
    {
        var organization = await _organizationQuery.FindByIdAsync(organizationRequest.Id);
        organization.Name = organizationRequest.Name;
        organization.Description = organizationRequest.Description;
        organization.Address = organizationRequest.Address;
        organization.ContactInfo = organizationRequest.ContactInfo;
        await _organizationCommand.UpdateAsync(organization);
    }
}