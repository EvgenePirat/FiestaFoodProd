using Business.Models.Enums;
using Business.Models.OrderDetails.Request;
using Business.Models.OrderItems.Request;

namespace Business.Models.Orders.Request
{
    public class UpdateOrderModel
    {
        public Guid Id { get; set; }
        public UpdateOrderDetailModel OrderDetail { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderFinishedDate { get; set; }
        public IEnumerable<UpdateOrderItemModel> OrderItems { get; set; }
    }
}
