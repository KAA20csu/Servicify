namespace Servicify.Core;

public class Service : IIdentityEntity
{
    private Service()
    {
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public List<Appointment> Appointments { get; set; }
    public List<AvailableTime> AvailableTimes { get; set; }
    public long Id { get; set; }
}