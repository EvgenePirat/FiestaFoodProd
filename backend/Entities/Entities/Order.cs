using Entities.Interfaces;

namespace Entities.Entities
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerInfoId { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }
        public double Price { get; set; }
        public Guid OrderDetailId { get; set; } 
        public virtual OrderDetail OrderDetail { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
