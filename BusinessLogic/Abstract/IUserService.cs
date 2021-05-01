using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IUserService
    {
         IDataResult<User> Register(RegisterUserDto registerUserDto);
    }
}
