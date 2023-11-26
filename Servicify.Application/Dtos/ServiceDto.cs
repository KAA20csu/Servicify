using Servicify.Core;

namespace Servicify.Application.Dtos
{
    public class ServiceDto
    {
        public string Name {get; set; }
        public string Description {get; set; }
        public List<AvailableTimeDto> AvailableTimes {get; set; }
    }
}
