using Business.Models.Enums;
using Entities.Entities;

namespace Business.Models.OrderDetails.Response
{
    public class OrderDetailModel
    {
        public Guid OrderId { get; set; }
        public double Sum { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
