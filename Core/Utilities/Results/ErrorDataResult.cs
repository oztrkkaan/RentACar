﻿using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {
        }
        public ErrorDataResult(T data, string message, IList<ValidationError> validationErrors) : base(data, false, validationErrors)
        {
        }
        public ErrorDataResult(T data, IList<ValidationError> validationErrors) : base(data, false, validationErrors)
        {
        }
        public ErrorDataResult() : base(default, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult(string message, IList<ValidationError> validationErrors) : base(default, false, message, validationErrors)
        {

        }
        public ErrorDataResult(IList<ValidationError> validationErrors) : base(default, false, validationErrors)
        {

        }

    }
}
