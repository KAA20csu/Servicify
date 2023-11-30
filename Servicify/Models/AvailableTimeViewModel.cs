namespace Servicify.Models;

public class AvailableTimeViewModel
{
    public long Id { get; set; }

    public long ServiceId { get; set; }
    public string Name { get; set; }
    public string Duration { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }

    public AvailableTimeViewModel(long id, string name, string duration, string date, string time, long serviceId)
    {
        Id = id;
        Name = name;
        Duration = duration;
        Date = date;
        Time = time;
        ServiceId = serviceId;
    }
}