using Servicify.Core;

namespace Servicify.Application.Dtos
{
    public class ServiceDto
    {
        public long Id { get; set; }
        public string Name {get; set; }
        public string Description {get; set; }
        public float Cost { get; set; }
        public List<AvailableTimeDto> AvailableTimes {get; set; }
    }
}
