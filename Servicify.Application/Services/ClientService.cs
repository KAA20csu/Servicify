using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientCommand _clientCommand;

    public ClientService(IClientCommand clientCommand)
    {
        _clientCommand = clientCommand;
    }
    
    public async Task<long> CreateAsync(Client client)
    {
        return await _clientCommand.CreateAsync(client);
    }

    public async Task DeleteAsync(Client client)
    {
        await _clientCommand.DeleteAsync(client);
    }

    public async Task UpdateAsync(Client client)
    {
        await _clientCommand.UpdateAsync(client);
    }
}