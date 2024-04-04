using Entities.Enums;
using Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Dish : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public string Image { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<DishIngridient> DishIngridients { get; set; }
    }
}
 