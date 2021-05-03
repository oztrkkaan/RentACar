using Entity.Constants;
using Entity.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarDto>
    {
        public CarValidator()
        {
            RuleFor(m => m.Brand).NotEmpty().WithMessage("Marka alanı boç geçilemez.");
            RuleFor(m => m.CarPlate).NotEmpty().WithMessage("Araç plakası alanı boç geçilemez.");
            RuleFor(m => m.Color).NotEmpty().WithMessage("Araç rengi alanı boç geçilemez.");
            RuleFor(m => m.DailyRentCost).GreaterThan(0).WithMessage("Günlük araç kiralama bedeli 0'dan büyük olmalı.");
            RuleFor(m => m.Type).InclusiveBetween((byte)1, (byte)CarEnum.TypeList.Count()).WithMessage("Lütfen araç tipi seçin.");
            RuleFor(m => m.Type).NotEmpty().WithMessage("Lütfen araç tipi seçin.");
            RuleFor(m => m.Currency).InclusiveBetween((byte)1, (byte)CurrencyEnum.CurrencyList.Count()).WithMessage("Lütfen para birimi seçin.");
            RuleFor(m => m.ModelYear).InclusiveBetween((short)1900, (short)DateTime.Now.Year).WithMessage("Lütfen aracın model yılını seçin.");
            RuleFor(m => m.ModelYear).NotEmpty().WithMessage("Lütfen aracın model yılını seçin.");
            RuleFor(m => m.VIN).NotEmpty().WithMessage("Şasi numarası alanı boş geçilemez.");
            RuleFor(m => m.Model).NotEmpty().WithMessage("Araç modeli alanı boş geçilemez.");
        }
    }
}
