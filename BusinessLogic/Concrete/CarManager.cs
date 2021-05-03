using BusinessLogic.Abstract;
using BusinessLogic.Utilities.AutoMapper;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using System.Collections.Generic;


namespace BusinessLogic.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<Car> Create(CarDto carDto)
        {
            var validator = new CarValidator();
            var validateResult = validator.Validate(carDto);

            if (!validateResult.IsValid)
            {
                var validationErrors = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Car>("Araba ekleme işlemi başarısız oldu.", validationErrors);
            }

            var addResult = _carDal.Add(Mapping.Mapper.Map<Car>(carDto));

            return new SuccessDataResult<Car>(addResult.Data, "Yeni araba başarıyla eklendi.");
        }

        public IDataResult<IList<Car>> GetAll()
        {
            return _carDal.GetAll();
        }

        public IDataResult<Car> GetById(int id)
        {
            return _carDal.GetById(id);
        }
    }
}
