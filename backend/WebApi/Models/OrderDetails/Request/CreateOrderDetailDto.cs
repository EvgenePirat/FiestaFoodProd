using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Request
{
    public class CreateOrderDetailDto
    {
        public PostType PostType { get; set; }
        public bool IsPaid { get; set; }
    }
}
