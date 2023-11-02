using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentCommand _appointmentCommand;

    public AppointmentService(IAppointmentCommand appointmentCommand)
    {
        _appointmentCommand = appointmentCommand;
    }
    
    public async Task<long> CreateAsync(Appointment appointment)
    {
        return await _appointmentCommand.CreateAsync(appointment);
    }

    public async Task DeleteAsync(Appointment appointment)
    {
        await _appointmentCommand.DeleteAsync(appointment);
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        await _appointmentCommand.UpdateAsync(appointment);
    }
}