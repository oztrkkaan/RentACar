using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Helper.FluentValidation
{
    public static class ValidationHelper
    {
        public static void ValidateModel(this ModelStateDictionary modelState, IList<ValidationError> validationErrors, Type type = null)
        {
            modelState.Clear();
            foreach (var error in validationErrors)
                modelState.AddModelError(type == null ? error.TypeName : type.Name + "." + error.PropertyName, error.ErrorMessage);
        }
    }
}