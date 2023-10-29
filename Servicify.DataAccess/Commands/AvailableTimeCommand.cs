using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.DataAccess.Commands;

public class AvailableTimeCommand : IAvailableTimeCommand
{
    private readonly AppDbContext _appDbContext;

    public AvailableTimeCommand(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> CreateAsync(AvailableTime availableTime)
    {
        await _appDbContext.AddAsync(availableTime);
        await _appDbContext.SaveChangesAsync();
        return availableTime.Id;
    }

    public async Task DeleteAsync(AvailableTime availableTime)
    {
        _appDbContext.AvailableTimes.Remove(availableTime);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(AvailableTime availableTime)
    {
        _appDbContext.AvailableTimes.Update(availableTime);
        await _appDbContext.SaveChangesAsync();
    }
}