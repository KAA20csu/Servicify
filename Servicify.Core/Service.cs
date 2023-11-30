namespace Servicify.Core;

public class Service : IIdentityEntity
{
    private Service()
    {
    }

    public Service(string name, string description, float cost, long organizationId, List<AvailableTime> availableTimes)
    {
        Name = name;
        Description = description;
        Cost = cost;
        OrganizationId = organizationId;
        Appointments = new List<Appointment>();
        Subscribers = new List<Client>();
        AvailableTimes = availableTimes;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public float Cost { get; set; }
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public List<Appointment> Appointments { get; set; }
    public List<AvailableTime> AvailableTimes { get; set; }
    public List<Client> Subscribers { get; set; }
    public long Id { get; set; }
}