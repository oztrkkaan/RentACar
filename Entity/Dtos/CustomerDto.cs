using Core.Entities;
using System;

namespace Entity.Dtos
{
    public class CustomerDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CompanyTitle { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public long CitizenshipNumber { get; set; }
        public long TaxNumber { get; set; }
        public string TaxAdministration { get; set; }
    }
}
