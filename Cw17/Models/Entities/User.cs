using Cw17.Models.Enums;

namespace Cw17.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }

    }
}
