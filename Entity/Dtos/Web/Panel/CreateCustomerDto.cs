using Core.Entities;
using System;

namespace Entity.Dtos.Web.Panel
{
    public class CreateCustomerDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CompanyTitle { get; set; }
        public short? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public long CitizenshipNumber { get; set; }
        public long TaxNumber { get; set; }
        public string TaxAdministration { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string FullAddress { get; set; }

        public string LandPhone { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
    }
}
