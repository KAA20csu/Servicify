using Servicify.Application.Requests;
using Servicify.Core;

namespace Servicify.Application.Services.Contracts;

public interface IAppointmentService
{
    public Task<long> CreateAsync(CreateAppointmentRequest createAppointmentRequest);
    public Task DeleteAsync(Appointment appointment);
    public Task UpdateAsync(Appointment appointment);
}