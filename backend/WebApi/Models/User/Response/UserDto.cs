using WebApi.Models.Enums;
using WebApi.Models.Orders.Response;

namespace WebApi.Models.User.Response
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
