using BusinessLogic.Abstract;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> Register(RegisterUserDto registerUserDto)
        {
            var validator = new UserValidator();
            var validateResult = validator.Validate(registerUserDto);

            if (!validateResult.IsValid)
            {
                var validationErros = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<User>("Kullanıcı oluşturma işlemi başarısız oldu.", validationErros);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerUserDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = registerUserDto.Email,
                FullName = registerUserDto.FullName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = "Owner"
            };

            return _userDal.Add(user);
        }
    }
}
