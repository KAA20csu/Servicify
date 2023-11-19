namespace Servicify.Core;

public class AvailableTime : IIdentityEntity
{
    private AvailableTime()
    {
    }

    public long ServiceID { get; set; }
    public Service Service { get; set; }
    public DateTime Date { get; set; }
    public long Id { get; set; }

    public AvailableTime(long serviceId, DateTime date)
    {
        ServiceID = serviceId;
        Date = date;
    }
}