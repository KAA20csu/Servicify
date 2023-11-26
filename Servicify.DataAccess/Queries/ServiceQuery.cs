using Microsoft.EntityFrameworkCore;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Servicify.DataAccess.Queries;

public class ServiceQuery : IServiceQuery
{
    private readonly AppDbContext _appDbContext;

    public ServiceQuery(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Service> FindByIdAsync(long id)
    {
        return (await _appDbContext
            .Services.Include(x => x.Subscribers)
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync())!;
    }

    public async Task<List<Service>> GetAllByOrganizationIdAsync(long organizationId)
    {
        return await _appDbContext
            .Services
            .Include(x => x.Subscribers)
            .Include(x => x.AvailableTimes)
            .Where(x => x.OrganizationId == organizationId)
            .ToListAsync();
    }

    public async Task<Service> FindByNameAsync(string name)
    {
        return (await _appDbContext
            .Services
            .Where(x => x.Name == name)
            .SingleOrDefaultAsync())!;
    }

    public async Task<List<Service>> GetAllAsync(string name)
    {
        return await _appDbContext
            .Services.AsNoTracking().ToListAsync();
    }
}