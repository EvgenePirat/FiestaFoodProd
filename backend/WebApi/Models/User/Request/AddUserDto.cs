using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.User.Request
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "Login must be in user")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password must be in user")]
        public string Password { get; set; }
    }
}
