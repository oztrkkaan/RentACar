using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {

        IDataResult<Car> Add(Car car);
        IDataResult<IList<Car>> GetAll();
        IDataResult<Car> GetById(int id);
    }
}
