using Business.Models.Enums;
using Business.Models.Orders.Response;
using Entities.Entities;

namespace Business.Models.Users.Response
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
    }
}
