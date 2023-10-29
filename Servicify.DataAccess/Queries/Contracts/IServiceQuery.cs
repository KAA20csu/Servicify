using Servicify.Core;

namespace Servicify.DataAccess.Queries.Contracts
{
    public interface IServiceQuery
    {
        public Task<Service> FindByIdAsync(long id);
        public Task<Service> FindByNameAsync(string name);
    }
}
