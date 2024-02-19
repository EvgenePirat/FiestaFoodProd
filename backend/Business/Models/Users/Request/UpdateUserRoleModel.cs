using Business.Models.Enums;

namespace Business.Models.Users.Request
{
    public class UpdateUserRoleModel
    {
        public Guid Id { get; set; }
        public Role Role { get; set; }
    }
}
