using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Services.Contracts;
using Servicify.DataAccess.Queries.Contracts;
using Servicify.Models;

namespace Servicify.Controllers
{
    [Authorize(Policy = "CookiePolicy")]
    [Route("time")]
    public class AvailableTimeController : Controller
    {
        private readonly IAvailableTimeQuery _availableTimeQuery;

        public AvailableTimeController(IAvailableTimeQuery availableTimeQuery)
        {
            _availableTimeQuery = availableTimeQuery;
        }

        [HttpGet("{serviceid}")]
        public async Task<IActionResult> AvailableTime(long serviceId)
        {
            var times = await _availableTimeQuery.FindByServiceIdAsync(serviceId);
            return View(times);
        }
    }
}
