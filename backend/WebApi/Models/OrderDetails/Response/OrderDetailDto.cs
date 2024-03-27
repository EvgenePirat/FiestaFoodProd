using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Response
{
    public class OrderDetailDto
    {
        public Guid OrderId { get; set; }
        public double Sum { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
