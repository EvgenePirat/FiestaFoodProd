using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class OrderItem : IEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int Count { get; set; }
        public string Comment { get; set; }
    }
}
