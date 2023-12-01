namespace Servicify.Application.Requests
{
    public class ServiceSubscribeRequest
    {
        public long ServiceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
