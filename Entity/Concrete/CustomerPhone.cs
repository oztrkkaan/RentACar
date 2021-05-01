﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class CustomerPhone : IEntity
    {
        public int Id { get; set; }
        public string LandPhone { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public int CustomerId { get; set; }
    }
}
