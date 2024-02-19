using Business.Models.Enums;

namespace Business.Models.OrderDetails.Response
{
    public class OrderDetailModel
    {
        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public OrderState OrderState { get; set; }
        public bool IsPaid { get; set; }
    }
}
