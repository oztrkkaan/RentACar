using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;

namespace DataAccess.Abstract
{
    public interface IBookingDal
    {
        IDataResult<Entity.Concrete.BookingDto> Add(Entity.Dtos.BookingDto bookingDto);

    }
}
