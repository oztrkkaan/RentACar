using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        IList<ValidationError> ValidationErrors { get; }
    }
}
