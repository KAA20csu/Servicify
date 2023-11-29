namespace Servicify.Core;

public class Organization : IIdentityEntity
{
    private Organization()
    {
    }

    public Organization(string name, string description, string address, string contactInfo, string password)
    {
        Name = name;
        Description = description;
        Address = address;
        ContactInfo = contactInfo;
        Password = password;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string ContactInfo { get; set; }
    public string Password { get; set; }
    public List<Service> Services { get; set; }
    public long Id { get; set; }
}