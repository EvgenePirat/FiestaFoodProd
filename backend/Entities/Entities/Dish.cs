using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class Dish : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string PhotoPaths { get; set; }
        public Size Size { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<DishIngridient> DishIngridients { get; set; }
    }
}
 