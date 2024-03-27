using Entities.Entities;
using WebApi.Models.IngredientsDto.Response;

namespace WebApi.Models.DishIngredientsDto.Response
{
    public class DishIngridientDto
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public double Count { get; set; }
    }
}
