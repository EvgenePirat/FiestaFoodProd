using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class OrderDetail : IEntity
    {
        public Guid Id { get; set; }
        public OrderState OrderState { get; set; }
        public bool IsPaid { get; set; }
        //public Guid PaymentInfoId { get; set; }
        //public virtual PaymentInfo PaymentInfo { get; set; }
    }
}
