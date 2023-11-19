using Microsoft.EntityFrameworkCore;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.DataAccess.Queries;

public class ClientQuery : IClientQuery
{
    private readonly AppDbContext _appDbContext;

    public ClientQuery(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Client> FindByIdAsync(long id)
    {
        return (await _appDbContext
            .Clients
            .Include(x => x.Subscriptions)
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync())!;
    }

    public async Task<Client> FindByNameAsync(string firstName, string lastName)
    {
        return (await _appDbContext
            .Clients
            .Where(x => x.FirstName == firstName && x.LastName == lastName)
            .SingleOrDefaultAsync())!;
    }

    public async Task<List<Client>> GetAllAsync(string firstName, string lastName)
    {
        return await _appDbContext
            .Clients.AsNoTracking().ToListAsync();
    }
}