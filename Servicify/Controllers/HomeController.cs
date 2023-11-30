using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Services.Contracts;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Controllers;

[Authorize(Policy = "CookiePolicy")]
public class HomeController : Controller
{
    private readonly IOrganizationService _organizationService;
    private readonly IOrganizationQuery _organizationQuery;

    public HomeController(IOrganizationService organizationService, IOrganizationQuery organizationQuery)
    {
        _organizationService = organizationService;
        _organizationQuery = organizationQuery;
    }
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        var orgs = await _organizationQuery.GetAllAsync();
        return View(orgs);
    }
}