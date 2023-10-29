using Servicify.Core;

namespace Servicify.DataAccess.Commands.Contracts;

public interface IAppointmentCommand
{
    public Task<long> CreateAsync(Appointment appointment);
    public Task DeleteAsync(Appointment appointment);
    public Task UpdateAsync(Appointment appointment);
}