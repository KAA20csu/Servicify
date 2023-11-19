namespace Servicify.Core;

public class Client : IIdentityEntity
{
    private Client()
    {
    }

    public Client(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Appointments = new List<Appointment>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Appointment> Appointments { get; set; }
    public long Id { get; set; }
}