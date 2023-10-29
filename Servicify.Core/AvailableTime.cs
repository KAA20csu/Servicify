namespace Servicify.Core;

public class AvailableTime : IIdentityEntity
{
    private AvailableTime()
    {
    }

    public long ServiceID { get; set; }
    public Service Service { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public long Id { get; set; }
}