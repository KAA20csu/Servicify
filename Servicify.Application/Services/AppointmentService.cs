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
    private readonly IClientCommand _clientCommand;

    public AppointmentService(IAppointmentCommand appointmentCommand, IAvailableTimeQuery availableTimeQuery, IClientCommand clientCommand)
    {
        _appointmentCommand = appointmentCommand;
        _availableTimeQuery = availableTimeQuery;
        _clientCommand = clientCommand;
    }

    public async Task<long> CreateAsync(CreateAppointmentRequest createAppointmentRequest)
    {
        var client = new Client(createAppointmentRequest.FirstName,
            createAppointmentRequest.LastName,
            createAppointmentRequest.Email,
            createAppointmentRequest.PhoneNumber);
        var clientId = await _clientCommand.CreateAsync(client);
        var availableTime = await _availableTimeQuery.FindByIdAsync(createAppointmentRequest.AvailableTimeId);
        var appointment = new Appointment(
            availableTime.Date,
            createAppointmentRequest.ServiceId, 
            clientId);
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