using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicify.Core;
using Servicify.DataAccess.Commands;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify
{
    [ApiController]
    [Route("client")]
    public class HomeController : ControllerBase
    {
        private readonly IClientCommand _clientCommand;
        public HomeController(IClientCommand clientCommand)
        {
            _clientCommand = clientCommand;
        }
        
        [HttpPost("create")]
        public Task<long> Create([FromBody] ClientRequest clientRequest)
        {
            var client = new Client(clientRequest.FirstName, clientRequest.LastName, clientRequest.Email,
                clientRequest.PhoneNumber);
            return _clientCommand.CreateAsync(client);
        }
    }

    public class ClientRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
