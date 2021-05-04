using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBookingDal
    {
        IDataResult<BookingDto> Add(BookingDto bookingDto);
        IDataResult<IList<BookingDto>> GetListByCarId(int carId);

    }
}
