using Entity.Dtos.Web.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels.Web.Panel
{
    public class AddCustomerViewModel : IViewModel
    {
        public CreateCustomerDto CreateCustomerDto { get; set; }
    }
}
