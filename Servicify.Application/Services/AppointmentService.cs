using Servicify.Application.Requests;
using Servicify.Application.Services.Contracts;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentCommand _appointmentCommand;
    private readonly IAvailableTimeQuery _availableTimeQuery;

    public AppointmentService(IAppointmentCommand appointmentCommand, IAvailableTimeQuery availableTimeQuery)
    {
        _appointmentCommand = appointmentCommand;
        _availableTimeQuery = availableTimeQuery;
    }
    
    public async Task<long> CreateAsync(CreateAppointmentRequest createAppointmentRequest)
    {
        var availableTime = await _availableTimeQuery.FindByIdAsync(createAppointmentRequest.AvailableTimeId);
        var appointment = new Appointment(
            availableTime.Date, 
            createAppointmentRequest.ServiceId,
            createAppointmentRequest.ClientId); 
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