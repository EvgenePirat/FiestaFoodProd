using WebApi.Models.OrderDetails.Request;

namespace WebApi.Models.Orders.Request
{
    public class CreateOrderDto
    {
        public Guid? CustomerInfoId { get; set; }
        public CreateOrderDetailDto OrderDetail { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
