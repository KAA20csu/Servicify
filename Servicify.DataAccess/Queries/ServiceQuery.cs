using Microsoft.EntityFrameworkCore;
using Servicify.Core;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.DataAccess.Queries
{
    public class ServiceQuery : IServiceQuery
    {
        private AppDbContext _appDbContext;
        public ServiceQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Service> FindByIdAsync(long id)
        {
            return (await _appDbContext
                .Services
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync())!;

        }

        public async Task<Service> FindByNameAsync(string name)
        {
            return (await _appDbContext
                .Services
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync())!;
        }
    }
}
