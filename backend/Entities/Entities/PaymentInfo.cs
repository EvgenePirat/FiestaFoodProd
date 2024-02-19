using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class PaymentInfo : IEntity
    {
        public Guid Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus UserPaymentStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
