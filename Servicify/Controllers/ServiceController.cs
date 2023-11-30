using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Dtos;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Controllers;

[Route("services")]
public class ServiceController : Controller
{
    private readonly IServiceService _serviceService;
    private readonly IServiceQuery _serviceQuery;

    public ServiceController(IServiceService serviceService, IServiceQuery serviceQuery)
    {
        _serviceService = serviceService;
        _serviceQuery = serviceQuery;
    }

    [HttpGet("{organizationId}")]
    public async Task<IActionResult> OrganizationServices(long organizationId)
    {
        var services = await _serviceService.GetAllByOrganizationId(organizationId);
        return View(services);
    }

    [HttpGet("all")]
    public Task<List<ServiceAllDto>> GetAllAsync()
    {
        return _serviceService.GetAllAsync();
    }
    [HttpPost]
    public Task<long> CreateService(ServiceCreateRequest serviceCreateRequest)
    {
        return _serviceService.CreateAsync(serviceCreateRequest);
    }

    [HttpPost("subscribe")]
    public Task Subscribe(ServiceSubscribeRequest serviceSubscribeRequest)
    {
        return _serviceService.Subscribe(serviceSubscribeRequest);
    }
}