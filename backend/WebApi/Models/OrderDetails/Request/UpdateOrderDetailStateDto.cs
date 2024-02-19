using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Request
{
    public class UpdateOrderDetailStateDto
    {
        public Guid Id { get; set; }
        public OrderState OrderState { get; set; }
    }
}
