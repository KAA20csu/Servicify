using Servicify.Core;

namespace Servicify.Application.Services.Contracts;

public interface IAppointmentService
{
    public Task<long> CreateAsync(Appointment appointment);
    public Task DeleteAsync(Appointment appointment);
    public Task UpdateAsync(Appointment appointment);
}