namespace Servicify.Core;

public class Client : IIdentityEntity
{
    private Client()
    {
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Appointment> Appointments { get; set; }
    public long Id { get; set; }
}