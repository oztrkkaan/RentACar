﻿namespace Core.Entities.Concrete
{
    public class ValidationError
    {
        public string TypeName { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
