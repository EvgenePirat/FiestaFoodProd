using Business.Models.Enums;

namespace Business.Models.OrderDetails.Request
{
    public class UpdateOrderDetailModel
    {
        public double Sum { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
