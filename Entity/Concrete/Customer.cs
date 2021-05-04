using Core.Entities;
using System;

namespace Entity.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CompanyTitle { get; set; }
        public short Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public long CitizenshipNumber { get; set; }
        public long TaxNumber { get; set; }
        public string TaxAdministration { get; set; }
    }
}
