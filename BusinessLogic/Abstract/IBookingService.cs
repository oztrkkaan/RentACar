using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;

namespace BusinessLogic.Abstract
{
    public interface IBookingService
    {
        IDataResult<Entity.Concrete.BookingDto> Create(Entity.Dtos.BookingDto bookingDto);
    }
}
