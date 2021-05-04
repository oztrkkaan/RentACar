using Core.Entities;

namespace Entity.Dtos
{
    public class CustomerAddressDto : IDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public int CustomerId { get; set; }
    }
}
