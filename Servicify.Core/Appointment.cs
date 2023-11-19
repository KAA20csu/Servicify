namespace Servicify.Core;

public class Appointment : IIdentityEntity
{
    private Appointment()
    {
    }

    public DateTime DateTime { get; set; }
    public long ServiceId { get; set; }
    public Service Service { get; set; }
    public long ClientId { get; set; }
    public Client Client { get; set; }
    public long Id { get; set; }

    public Appointment(DateTime dateTime, long serviceId, long clientId)
    {
        DateTime = dateTime;
        ServiceId = serviceId;
        ClientId = clientId;
    }
}