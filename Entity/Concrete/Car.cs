using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public short ModelYear { get; set; }
        public string CarPlate { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public decimal DailyRentCost { get; set; }
        public byte Type { get; set; }
        public byte Currency { get; set; }
    }
}
