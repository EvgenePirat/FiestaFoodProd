using WebApi.Models.Enums;
using WebApi.Models.OrdemItems.Request;
using WebApi.Models.OrderDetails.Request;

namespace WebApi.Models.Orders.Request
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public UpdateOrderDetailDto OrderDetail { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderFinishedDate { get; set; }
        public IEnumerable<UpdateOrderItemDto> OrderItems { get; set; }
    }
}
