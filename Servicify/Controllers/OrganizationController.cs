using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Controllers
{
    
    [Route("organization")]
    public class OrganizationController : Controller
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

        [Authorize(Policy = "CookiePolicy")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var orgId = Request.Cookies["OrgId"];
            var organization = await _organizationQuery.FindByIdAsync(long.Parse(orgId!));
            return View(organization);
        }

        [Authorize(Policy = "CookiePolicy")]
        [HttpPost]
        public Task EditOrganization(EditOrganizationRequest editOrganizationRequest)
        {
            return _organizationService.UpdateAsync(editOrganizationRequest);
        }
    }
}
