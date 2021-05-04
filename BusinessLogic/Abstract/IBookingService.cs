using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using System.Collections.Generic;

namespace BusinessLogic.Abstract
{
    public interface IBookingService
    {
        IDataResult<IList<BookingDto>> GetListByCarId(int carId);
        IDataResult<BookingDto> Create(BookingDto bookingDto);
    }
}
