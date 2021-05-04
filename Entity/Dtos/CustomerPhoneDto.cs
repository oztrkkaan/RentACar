using Core.Entities;

namespace Entity.Dtos
{
    public class CustomerPhoneDto : IDto
    {
        public int Id { get; set; }
        public string LandPhone { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public int CustomerId { get; set; }
    }
}
