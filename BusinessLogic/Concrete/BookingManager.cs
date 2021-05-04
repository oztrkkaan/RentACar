using BusinessLogic.Abstract;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Dtos;
using System.Collections.Generic;

namespace BusinessLogic.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public IDataResult<BookingDto> Create(Entity.Dtos.BookingDto bookingDto)
        {
            var validator = new BookingValidator();
            var validateResult = validator.Validate(bookingDto);

            if (!validateResult.IsValid)
            {
                var validationErrors = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<BookingDto>("Rezervasyon ekleme işlemi başarısız oldu.", validationErrors);
            }
            return _bookingDal.Add(bookingDto);
        }

        public IDataResult<IList<BookingDto>> GetListByCarId(int carId)
        {
            return _bookingDal.GetListByCarId(carId);
        }
    }
}
