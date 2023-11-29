using Microsoft.AspNetCore.Mvc;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;
using Servicify.DataAccess.Queries.Contracts;
using Servicify.Models;

namespace Servicify.Controllers;

[Route("/auth")]
public class AuthController : Controller
{
    private readonly IOrganizationCommand _organizationCommand;
    private readonly IOrganizationQuery _organizationQuery;
    public AuthController(IOrganizationCommand organizationCommand, IOrganizationQuery organizationQuery)
    {
        _organizationCommand = organizationCommand;
        _organizationQuery = organizationQuery;
    }

    [Route("login")]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        var org = await _organizationQuery.FindByNameAsync(loginViewModel.Name);
        if(org.Password == loginViewModel.Password)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            };
            Response.Cookies.Append("AccessGUID", Guid.NewGuid().ToString(), cookieOptions);
        }
        return View();
    }
    
    [Route("signup")]
    public IActionResult Register(RegisterViewModel registerViewModel)
    {
        var org = new Organization(registerViewModel.Name, registerViewModel.Description, registerViewModel.Address, registerViewModel.ContactInfo, registerViewModel.Password);
        _organizationCommand.CreateAsync(org);
        return View();
    }
}