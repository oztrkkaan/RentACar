using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Customer : IEntity
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
