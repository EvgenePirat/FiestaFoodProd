using System.ComponentModel.DataAnnotations;
using WebApi.Models.Enums;

namespace WebApi.Models.User.Request
{
    public class UpdateUserRoleDto
    {
        [Required(ErrorMessage = "Id required for updating user")]
        public Guid Id { get; set; }

        public Role Role { get; set; }
    }
}
