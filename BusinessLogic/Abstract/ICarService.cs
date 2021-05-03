using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> Create(CarDto carDto);
        IDataResult<IList<Car>> GetAll();
        IDataResult<Car> GetById(int id);
    }
}
