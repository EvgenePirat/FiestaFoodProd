using Business.Models.Enums;

namespace Business.Models.OrderDetails.Request
{
    public class CreateOrderDetailModel
    {
        public PostType PostType { get; set; }
        public bool IsPaid { get; set; }
    }
}
