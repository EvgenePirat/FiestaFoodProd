using Entities.Interfaces;

namespace Entities.Entities
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public int OrderCardNumber { get; set; }
        public Guid CustomerInfoId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public double Price { get; set; }
        public Guid OrderDetailId { get; set; } 
        public OrderDetail OrderDetail { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}
