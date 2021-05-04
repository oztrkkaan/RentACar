using Entity.Dtos;
using FluentValidation;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {
        public BookingValidator()
        {
            RuleFor(m => m.BookingDate).NotEmpty().WithMessage("Rezervasyon başlangıç tarihi boç geçilemez.");
            RuleFor(m => m.BookingEndDate).NotEmpty().WithMessage("Rezervasyon bitiş tarihi boş geçilemez.");
            RuleFor(m => m.CarId).NotEmpty().WithMessage("Araç kimliği boç geçilemez.");
            RuleFor(m => m.CustomerId).NotEmpty().WithMessage("Müşteri bilgisi boş geçilemez");
        }
    }
}
