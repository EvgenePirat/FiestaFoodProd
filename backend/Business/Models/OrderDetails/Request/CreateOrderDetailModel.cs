using Business.Models.Enums;

namespace Business.Models.OrderDetails.Request
{
    public class CreateOrderDetailModel
    {
        public double Sum { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
