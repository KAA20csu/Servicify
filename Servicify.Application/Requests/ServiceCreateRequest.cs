using Servicify.Core;

namespace Servicify.Requests
{
    public class ServiceCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long OrganizationId { get; set; }
        public List<DateTime> AvailableTime { get; set; }
    }
}
