﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class ValidationError
    {
        public string TypeName { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
