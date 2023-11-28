using Microsoft.AspNet.Identity;
using Servicify.Core;

namespace Servicify.UserStore
{
    public class OrganizationUserStore : IUserStore<Organization>
    {
        static readonly List<Organization> Users = new List<Organization>();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Organization user)
        {
            return Task.Factory.StartNew(() => Users.Add(user));
        }

        public Task UpdateAsync(Organization user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Organization user)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> FindByNameAsync(string userName)
        {
            return Task<Organization>.Factory.StartNew(() => Users.FirstOrDefault(u => u.UserName == userName));
        }
    }
}
