namespace Servicify.Application.Requests
{
    public class EditOrganizationRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public long Id { get; set; }
    }
}
