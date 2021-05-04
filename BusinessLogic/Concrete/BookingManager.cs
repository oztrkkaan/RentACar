using BusinessLogic.Abstract;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;

namespace BusinessLogic.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public IDataResult<Entity.Concrete.BookingDto> Create(Entity.Dtos.BookingDto bookingDto)
        {
            var validator = new BookingValidator();
            var validateResult = validator.Validate(bookingDto);

            if (!validateResult.IsValid)
            {
                var validationErrors = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Entity.Concrete.BookingDto>("Rezervasyon ekleme işlemi başarısız oldu.", validationErrors);
            }
            return _bookingDal.Add(bookingDto);
        }
    }
}
