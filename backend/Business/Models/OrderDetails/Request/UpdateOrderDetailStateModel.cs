using Business.Models.Enums;

namespace Business.Models.OrderDetails.Request
{
    public class UpdateOrderDetailStateModel
    {
        public Guid Id { get; set; }
        public OrderState OrderState { get; set; }
    }
}
