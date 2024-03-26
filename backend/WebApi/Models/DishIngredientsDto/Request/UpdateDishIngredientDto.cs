using Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DishIngredientsDto.Request
{
    public class UpdateDishIngredientDto
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public double Count { get; set; }
    }
}
