﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Dtos;
using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.DataAccess.Queries.Contracts;
using Servicify.Models;

namespace Servicify.Controllers;

[Authorize(Policy = "CookiePolicy")]
[Route("services")]
public class ServiceController : Controller
{
    private readonly IServiceService _serviceService;
    private readonly IServiceQuery _serviceQuery;
    private readonly IOrganizationQuery _organizationQuery;

    public ServiceController(IServiceService serviceService, IServiceQuery serviceQuery, IOrganizationQuery organizationQuery)
    {
        _serviceService = serviceService;
        _serviceQuery = serviceQuery;
        _organizationQuery = organizationQuery;
    }

    [HttpGet("{organizationId}")]
    public async Task<IActionResult> OrganizationServices(long organizationId)
    {
        var services = await _organizationQuery.FindByIdAsync(organizationId);
        return View(services);
    }

    [HttpGet("all")]
    public Task<List<ServiceAllDto>> GetAllAsync()
    {
        return _serviceService.GetAllAsync();
    }

    [Authorize(Policy = "CookiePolicy")]
    [HttpGet("create")]
    public IActionResult CreateService()
    {
        return View();
    }

    [Authorize(Policy = "CookiePolicy")]
    [HttpPost("create")]
    public Task<long> CreateService([FromBody] CreateServiceViewModel createServiceViewModel)
    {
        var orgId = Request.Cookies["OrgId"];
        var service = new ServiceCreateRequest() {  
            OrganizationId = long.Parse(orgId), 
            Name = createServiceViewModel.Name, 
            Description = createServiceViewModel.Description, 
            Cost = createServiceViewModel.Cost, 
            AvailableTime = createServiceViewModel.AvailableTimes};

        return _serviceService.CreateAsync(service);
    }

    [HttpPost("subscribe")]
    public Task Subscribe([FromBody] ServiceSubscribeRequest serviceSubscribeRequest)
    {
        return _serviceService.Subscribe(serviceSubscribeRequest);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> ViewService(long id)
    {
        var service = await _serviceQuery.FindByIdAsync(id);
        return View(service);
    }
}