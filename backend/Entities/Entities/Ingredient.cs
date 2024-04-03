using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Quantity Quantity { get; set; }
        public IEnumerable<DishIngridient> DishIngridients { get; set; }
    }
}
