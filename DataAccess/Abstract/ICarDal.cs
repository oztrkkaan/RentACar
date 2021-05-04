using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {

        IDataResult<Car> Add(Car car);
        IDataResult<IList<Car>> GetAll();
        IDataResult<Car> GetById(int id);
    }
}
