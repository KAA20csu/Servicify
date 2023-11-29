namespace Servicify.Models;

public class ServiceViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Duration { get; set; }
    public float Cost { get; set; }

    public ServiceViewModel(long id, string name, string duration, float cost)
    {
        Id = id;
        Name = name;
        Duration = duration;
        Cost = cost;
    }
}