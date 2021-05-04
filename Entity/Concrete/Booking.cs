using Core.Entities;
using System;

namespace Entity.Concrete
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime BookingDate { get; set; }
        public short BookingTime { get; set; }
        public DateTime BookingEndDate { get; set; }
        public decimal Amount { get; set; }
    }
}
