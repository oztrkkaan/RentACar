using Entity.Dtos.Web.Auth;

namespace Entity.ViewModels.Web.Auth
{
    public class LoginViewModel : IViewModel
    {
        public LoginUserDto LoginUserDto { get; set; }
        public string LoginMessage { get; set; }
    }
}
