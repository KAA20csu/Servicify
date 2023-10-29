using Servicify.Core;

namespace Servicify.DataAccess.Queries.Contracts
{
    public interface IAppointmentQuery
    {
        public Task<Appointment> FindByIdAsync(long id);
    }
}
