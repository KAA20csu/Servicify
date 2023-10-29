using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.DataAccess.Commands
{
    public class ServiceCommand : IServiceCommand
    {
        private AppDbContext _appDbContext;
        public ServiceCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<long> CreateAsync(Service service)
        {
            await _appDbContext.AddAsync(service);
            await _appDbContext.SaveChangesAsync();
            return service.Id;
        }

        public async Task DeleteAsync(Service service)
        {
            _appDbContext.Services.Remove(service);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(Service service)
        {
            _appDbContext.Services.Update(service);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
