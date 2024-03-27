using Business.Models.OrderDetails.Response;
using WebApi.Models.Enums;
using WebApi.Models.OrdemItems.Response;
using WebApi.Models.OrderDetails.Response;

namespace WebApi.Models.Orders.Response
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public OrderDetailDto OrderDetail { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderFinishedDate { get; set; }
    }
}
