using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Controllers
{

    [Route("api/orgs")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationQuery _organizationQuery;

        public OrganizationController(IOrganizationService organizationService, IOrganizationQuery organizationQuery)
        {
            _organizationService = organizationService;
            _organizationQuery = organizationQuery;
        }

        [HttpGet]
        public Task<List<Organization>> GetAll()
        {
            return _organizationQuery.GetAllAsync();
        }

        [HttpPost]
        public Task EditOrganization(EditOrganizationRequest editOrganizationRequest)
        {
            return _organizationService.UpdateAsync(editOrganizationRequest);
        }
    }
}
