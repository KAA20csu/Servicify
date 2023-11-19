using Microsoft.EntityFrameworkCore;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.DataAccess.Queries;

public class AvailableTimeQuery : IAvailableTimeQuery
{
    private readonly AppDbContext _appDbContext;

    public AvailableTimeQuery(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AvailableTime> FindByIdAsync(long id)
    {
        return (await _appDbContext
            .AvailableTimes
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync())!;
    }

    public async Task<List<AvailableTime>> GetAllAsync(long id)
    {
        return await _appDbContext
            .AvailableTimes.AsNoTracking().ToListAsync();
    }
}