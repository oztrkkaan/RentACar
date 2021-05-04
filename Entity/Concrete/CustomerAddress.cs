using Core.Entities;

namespace Entity.Concrete
{
    public class CustomerAddress : IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public int CustomerId { get; set; }
    }
}
