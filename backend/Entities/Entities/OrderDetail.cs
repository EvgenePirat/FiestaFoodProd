using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class OrderDetail : IEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public double Sum { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
