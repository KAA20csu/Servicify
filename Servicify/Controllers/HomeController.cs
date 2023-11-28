using Microsoft.AspNetCore.Mvc;

namespace Servicify.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}