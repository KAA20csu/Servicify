using Microsoft.AspNetCore.Mvc;

namespace Servicify.Controllers;

[Route("/auth")]
public class AuthController : Controller
{
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }
    
    [Route("signup")]
    public IActionResult Register()
    {
        return View();
    }
}