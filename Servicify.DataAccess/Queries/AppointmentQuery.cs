using Microsoft.EntityFrameworkCore;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.DataAccess.Queries;

public class AppointmentQuery : IAppointmentQuery
{
    private readonly AppDbContext _appDbContext;

    public AppointmentQuery(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Appointment> FindByIdAsync(long id)
    {
        return (await _appDbContext
            .Appointments
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync())!;
    }

    public async Task<List<Appointment>> GetAllAsync(long id)
    {
        return await _appDbContext
            .Appointments.AsNoTracking().ToListAsync();
    }
}