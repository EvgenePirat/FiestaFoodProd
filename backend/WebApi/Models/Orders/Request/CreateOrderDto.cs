using Entities.Entities;
using WebApi.Models.Enums;
using WebApi.Models.OrdemItems.Request;
using WebApi.Models.OrderDetails.Request;

namespace WebApi.Models.Orders.Request
{
    public class CreateOrderDto
    {
        public CreateOrderDetailDto OrderDetail { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public IEnumerable<CreateOrderItemDto> OrderItems { get; set; }
    }
}
