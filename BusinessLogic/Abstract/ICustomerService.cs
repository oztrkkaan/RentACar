using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Web.Panel;
using System.Collections.Generic;

namespace BusinessLogic.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> Create(CreateCustomerDto createCustomerDto);
        IDataResult<IList<Customer>> GetAll();
    }
}
