using BusinessLogic.Abstract;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Web.Panel;
using System.Collections.Generic;

namespace BusinessLogic.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IDataResult<Customer> Create(CreateCustomerDto createCustomerDto)
        {
            var validator = new CustomerValidator();
            var validatorResult = validator.Validate(createCustomerDto);

            if (!validatorResult.IsValid)
            {
                var validationErrors = ValidationHelper.GetErrors(validatorResult.Errors);
                return new ErrorDataResult<Customer>("Müşteri ekleme işlemi başarısız oldu.", validationErrors);
            }
            var addedResult = _customerDal.AddWithAddressAndPhone(createCustomerDto);

            return addedResult;
        }

        public IDataResult<IList<Customer>> GetAll()
        {
            return _customerDal.GetAll();
        }
    }
}
