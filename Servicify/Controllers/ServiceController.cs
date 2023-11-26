using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Dtos;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Controllers;

[Route("api/services")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IServiceQuery _serviceQuery;

    public ServiceController(IServiceService serviceService, IServiceQuery serviceQuery)
    {
        _serviceService = serviceService;
        _serviceQuery = serviceQuery;
    }

    [HttpGet]
    public Task<List<ServiceDto>> GetAllByOrganizationIdAsync([FromQuery] long organizationId)
    {
        return _serviceService.GetAllByOrganizationId(organizationId);
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