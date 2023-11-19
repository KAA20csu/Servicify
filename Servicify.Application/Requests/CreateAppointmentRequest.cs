namespace Servicify.Application.Requests
{
    public class CreateAppointmentRequest
    {
        public long AvailableTimeId { get; set; }
        public long ServiceId { get; set; }
        public long ClientId { get; set; }
    }
}
