using Entity.Dtos.Web.Panel;
using FluentValidation;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<CreateCustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(m => m.BirthDate).NotEmpty().WithMessage("Doğum günü alanı boş geçilemez.");
            RuleFor(m => m.CitizenshipNumber).GreaterThan(1000000000).WithMessage("T.C. Kimlik No. alanı boş geçilemez.");
            RuleFor(m => m.CityName).NotEmpty().WithMessage("Şehir alanı boş geçilemez.");
            RuleFor(m => m.DistrictName).NotEmpty().WithMessage("İlçe alanı boş geçilemez.");
            RuleFor(m => m.FullAddress).NotEmpty().WithMessage("Açık adres alanı boş geçilemez.");
            RuleFor(m => m.FullName).NotEmpty().WithMessage("Tam Ad alanı boş geçilemez.");
            RuleFor(m => m.Gender).NotEmpty().WithMessage("Cinsiyet alanı boş geçilemez.");
            RuleFor(m => m.LandPhone).NotEmpty().WithMessage("Sabit telefon alanı boş geçilemez.");
            RuleFor(m => m.MobilePhone).NotEmpty().WithMessage("Cep telefon alanı boş geçilemez.");
            RuleFor(m => m.OfficePhone).NotEmpty().WithMessage("İş telefon alanı boş geçilemez.");

        }
    }
}
