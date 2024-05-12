using Entities.Entities;

namespace WebApi.Models.DishIngredientsDto.Request
{
    public class CreateDishIngridientDto
    {
        public int Id { get; set; }
        public double Count { get; set; }
    }
}
