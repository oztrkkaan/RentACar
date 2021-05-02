using Entity.Dtos.Web.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<RegisterUserDto>
    {
        public UserValidator()
        {
            RuleFor(m => m.FullName).NotEmpty().WithMessage("Tam ad alanı boş geçilemez.");
            RuleFor(m => m.FullName).MaximumLength(50).WithMessage("Tam ad alanı 50 karakterden büyük olamaz.");

            RuleFor(m => m.Email).NotEmpty().WithMessage("E-posta alanı boç geçilemez");
            RuleFor(m => m.Email).MaximumLength(50).WithMessage("E-posta alanı 50 karakterden büyük olamaz");
            RuleFor(m => m.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.");

            RuleFor(m => m.Password).MinimumLength(6).WithMessage("Şifre 6 veya daha fazla karakter içermelidir.");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");

            RuleFor(m => m.PasswordConfirm).Equal(m => m.Password).WithMessage("Şifre ve şifre tekrarı alanı aynı olmalı.");
        }
    }
}
