using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;
using Servicify.DataAccess.Queries.Contracts;
using Servicify.Models;
using System.Security.Claims;

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
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // Чтобы удалить куки, которые вы создали в прошлом методе
        Response.Cookies.Delete("AccessGUID");
        Response.Cookies.Delete("OrgId");

        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost("login")]
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
            string guid = Guid.NewGuid().ToString();
            Response.Cookies.Append("AccessGUID", guid, cookieOptions);
            Response.Cookies.Append("OrgId", org.Id.ToString(), cookieOptions);
            var claims = new List<Claim>
            {
                new Claim("AccessGUID", guid),
                new Claim("OrgId", org.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("signup")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("signup")]
    public IActionResult Register(RegisterViewModel registerViewModel)
    {
        var org = new Organization(registerViewModel.Name, registerViewModel.Description, registerViewModel.Address, registerViewModel.ContactInfo, registerViewModel.Password);
        _organizationCommand.CreateAsync(org);
        return RedirectToAction("Login");
    }
}