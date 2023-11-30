using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;

namespace Servicify.Controllers;

[Authorize(Policy = "CookiePolicy")]
[Route("api/appointment")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public Task<long> CreateAppointment(CreateAppointmentRequest createAppointmentRequest)
    {
        return _appointmentService.CreateAsync(createAppointmentRequest);
    }
}