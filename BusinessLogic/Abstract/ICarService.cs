using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using System.Collections.Generic;

namespace BusinessLogic.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> Create(CarDto carDto);
        IDataResult<IList<Car>> GetAll();
        IDataResult<Car> GetById(int id);
    }
}
