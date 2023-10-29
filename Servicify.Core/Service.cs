namespace Servicify.Core
{
    public class Service : IIdentityEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<AvailableTime> AvailableTimes { get; set; }
        private Service()
        {

        }
    }
}
