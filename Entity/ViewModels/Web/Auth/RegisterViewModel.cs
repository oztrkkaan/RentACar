using Entity.Dtos.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels.Web.Auth
{
    public class RegisterViewModel : IViewModel
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }
}
