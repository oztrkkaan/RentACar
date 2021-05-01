using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime BookingDate { get; set; }
        public short  BookingTime { get; set; }
        public DateTime BookingEndDate { get; set; }
        public decimal Amount { get; set; }
    }
}
