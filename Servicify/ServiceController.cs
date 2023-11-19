using Microsoft.AspNetCore.Mvc;
using Servicify.Application.Services.Contracts;
using Servicify.Requests;

namespace Servicify
{
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
}
