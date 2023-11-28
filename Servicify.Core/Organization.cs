namespace Servicify.Core;

public class Organization : IIdentityEntity
{
    private Organization()
    {
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string ContactInfo { get; set; }
    public List<Service> Services { get; set; }
    public long Id { get; set; }
}