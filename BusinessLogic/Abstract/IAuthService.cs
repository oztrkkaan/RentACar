using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Web.Auth;
using System.Web;

namespace BusinessLogic.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterUserDto registerUserDto);

        IResult Login(LoginUserDto loginUserDto, HttpContextBase httpContextBase);

    }
}
