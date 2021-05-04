using Core.Utilities.Results;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        IDataResult<User> Add(User user);
        IDataResult<User> GetByMail(string email);


    }
}
