using Business.Models.Dishes;
using Business.Models.Enums;
using Business.Models.OrderDetails.Response;
using Business.Models.OrderItems.Response;
using Entities.Entities;

namespace Business.Models.Orders.Response
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public IEnumerable<OrderItemModel> OrderItems { get; set; }
        public OrderDetailModel OrderDetail { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderFinishedDate { get; set; }
    }
}
