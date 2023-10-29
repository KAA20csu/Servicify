using Servicify.Core;

namespace Servicify.DataAccess.Queries.Contracts
{
    public interface IAvailableTimeQuery
    {
        public Task<AvailableTime> FindByIdAsync(long id);
    }
}
