using Business.Models.Enums;
using Business.Models.OrderDetails.Request;
using Business.Models.OrderItems.Request;

namespace Business.Models.Orders.Request
{
    public class CreateOrderModel
    {
        public CreateOrderDetailModel OrderDetail { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public IEnumerable<CreateOrderItemModel> OrderItems { get; set; }
    }
}
