using Core.Entities;

namespace Entity.Dtos
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }
}
