using Microsoft.EntityFrameworkCore;
using Servicify.Core;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.DataAccess.Commands
{
    public class OrganizationCommand : IOrganizationCommand
    {
        private AppDbContext _appDbContext;
        public OrganizationCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<long> CreateAsync(Organization organization)
        {
            await _appDbContext.AddAsync(organization);
            await _appDbContext.SaveChangesAsync();
            return organization.Id;
        }

        public async Task DeleteAsync(Organization organization)
        {
            _appDbContext.Organizations.Remove(organization);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(Organization organization)
        {
            _appDbContext.Organizations.Update(organization);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
