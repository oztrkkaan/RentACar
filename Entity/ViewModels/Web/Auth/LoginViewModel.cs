using Entity.Dtos.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels.Web.Auth
{
    public class LoginViewModel : IViewModel
    {
        public LoginUserDto LoginUserDto { get; set; }
        public string LoginMessage { get; set; }
    }
}
