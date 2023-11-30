using Servicify.Core;

namespace Servicify.Models
{
    public class CreateServiceViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public List<DateTime> AvailableTimes { get; set; }
    }
}
