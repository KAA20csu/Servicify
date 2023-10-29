namespace Servicify.Core
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public long ServiceId { get; set; }
        public Service Service { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
    }
}
