using Core.Entities;

namespace Entity.Dtos.Web.Auth
{
    public class LoginUserDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
