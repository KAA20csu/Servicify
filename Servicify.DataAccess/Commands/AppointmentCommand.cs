using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.DataAccess.Commands;

public class AppointmentCommand : IAppointmentCommand
{
    private readonly AppDbContext _appDbContext;

    public AppointmentCommand(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> CreateAsync(Appointment appointment)
    {
        await _appDbContext.AddAsync(appointment);
        await _appDbContext.SaveChangesAsync();
        return appointment.Id;
    }

    public async Task DeleteAsync(Appointment appointment)
    {
        _appDbContext.Appointments.Remove(appointment);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _appDbContext.Appointments.Update(appointment);
        await _appDbContext.SaveChangesAsync();
    }
}