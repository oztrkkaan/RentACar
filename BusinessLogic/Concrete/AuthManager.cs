using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Web.Auth;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace BusinessLogic.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;

        public AuthManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Login(LoginUserDto loginUserDto, HttpContextBase httpContextBase)
        {
            var user = _userDal.GetByMail(loginUserDto.Email);

            if (!user.Success)
            {
                return new ErrorResult(user.Message);
            }
            if (!HashingHelper.VerifyPasswordHash(loginUserDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return new ErrorResult("E-posta veya şifre hatalı.");
            }

            var identity = new ClaimsIdentity(new[] {
                new Claim(CustomClaimTypes.UserId, user.Data.Id.ToString()),
                new Claim(CustomClaimTypes.UserFullName, user.Data.FullName),
                new Claim(CustomClaimTypes.UserEmail, user.Data.Email),
                new Claim(ClaimTypes.Role, user.Data.Roles)
            }, "ApplicationCookie");

            var ctx = httpContextBase.Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = claimsPrincipal;
            return new SuccessResult("Oturum açıldı.");
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
