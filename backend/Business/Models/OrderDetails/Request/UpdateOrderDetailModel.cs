using Business.Models.Enums;

namespace Business.Models.OrderDetails.Request
{
    public class UpdateOrderDetailModel
    {
        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public OrderState OrderState { get; set; }
        public bool IsPaid { get; set; }
    }
}
