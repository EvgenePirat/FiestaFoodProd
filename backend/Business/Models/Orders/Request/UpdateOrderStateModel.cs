using Business.Models.Enums;

namespace Business.Models.Orders.Request
{
    public class UpdateOrderStateModel
    {
        public Guid OrderId { get; set; }
        public OrderState OrderState { get; set; }
    }
}
