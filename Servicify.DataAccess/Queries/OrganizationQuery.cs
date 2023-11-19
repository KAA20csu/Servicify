using Microsoft.EntityFrameworkCore;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.DataAccess.Queries;

public class OrganizationQuery : IOrganizationQuery
{
    private readonly AppDbContext _appDbContext;

    public OrganizationQuery(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Organization> FindByIdAsync(long id)
    {
        return (await _appDbContext
            .Organizations
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync())!;
    }

    public async Task<Organization> FindByNameAsync(string name)
    {
        return (await _appDbContext
            .Organizations
            .Where(x => x.Name == name)
            .SingleOrDefaultAsync())!;
    }

    public async Task<List<Organization>> GetAllAsync(string name)
    {
        return await _appDbContext
            .Organizations.AsNoTracking().ToListAsync();
    }
}