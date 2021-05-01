using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Dtos.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        IDataResult<User> Add(User user);

    }
}
