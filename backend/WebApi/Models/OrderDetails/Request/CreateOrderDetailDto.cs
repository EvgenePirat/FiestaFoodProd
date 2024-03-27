using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Request
{
    public class CreateOrderDetailDto
    {
        public double Sum { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
