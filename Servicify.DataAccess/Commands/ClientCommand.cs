using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.DataAccess.Commands;

public class ClientCommand : IClientCommand
{
    private readonly AppDbContext _appDbContext;

    public ClientCommand(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> CreateAsync(Client client)
    {
        await _appDbContext.AddAsync(client);
        await _appDbContext.SaveChangesAsync();
        return client.Id;
    }

    public async Task DeleteAsync(Client client)
    {
        _appDbContext.Clients.Remove(client);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        _appDbContext.Clients.Update(client);
        await _appDbContext.SaveChangesAsync();
    }
}