using Entities.Entities;

namespace WebApi.Models.DishIngredientsDto.Request
{
    public class CreateDishIngridientDto
    {
        public int IngredientId { get; set; }
        public double Count { get; set; }
    }
}
