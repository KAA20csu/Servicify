using Microsoft.AspNet.Identity;

namespace Servicify.Core;

public class Organization : IUser
{
    private Organization()
    {
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string ContactInfo { get; set; }
    public List<Service> Services { get; set; }
    public string Id { get; set; }
    public string UserName { get; set; }
}