using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;

namespace Servicify.Controllers;

[Route("api/services")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpPost]
    public Task<long> CreateService(ServiceCreateRequest serviceCreateRequest)
    {
        return _serviceService.CreateAsync(serviceCreateRequest);
    }
}