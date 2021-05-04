using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Web.Panel;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICustomerDal
    {
        IDataResult<Customer> AddWithAddressAndPhone(CreateCustomerDto createCustomerDto);

        IDataResult<IList<Customer>> GetAll();
    }
}
