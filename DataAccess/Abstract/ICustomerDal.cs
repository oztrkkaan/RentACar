using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Web.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerDal
    {
        IDataResult<Customer> AddWithAddressAndPhone(CreateCustomerDto createCustomerDto);
    }
}
