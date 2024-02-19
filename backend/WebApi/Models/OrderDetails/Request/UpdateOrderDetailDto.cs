using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Request
{
    public class UpdateOrderDetailDto
    {
        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public OrderState OrderState { get; set; }
        public bool IsPaid { get; set; }
    }
}
