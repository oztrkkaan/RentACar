﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
