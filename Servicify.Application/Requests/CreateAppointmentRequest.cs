namespace Servicify.Application.Requests;

public class CreateAppointmentRequest
{
    public long AvailableTimeId { get; set; }
    public long ServiceId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}