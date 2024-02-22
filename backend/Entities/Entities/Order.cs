using Entities.Interfaces;

namespace Entities.Entities
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public byte OrderCardNumber { get; set; }
        public Guid CustomerInfoId { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }
        public double Price { get; set; }
        public Guid OrderDetailId { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderFinishedDate { get; set; }
        public DateTime OrderOnTime { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}
