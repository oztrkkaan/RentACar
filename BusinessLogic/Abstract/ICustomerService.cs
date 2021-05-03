using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Web.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> Create(CreateCustomerDto createCustomerDto);
    }
}
