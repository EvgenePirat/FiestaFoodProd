using Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class DishIngredient : IEntity
    {
        public int DishId { get; set; }

        [ForeignKey("DishId")]
        public Dish Dish { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }

        public double Count { get; set; }
    }
}
