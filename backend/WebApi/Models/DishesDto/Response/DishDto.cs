using Business.Models.DishIngredients.Response;
using WebApi.Models.DishIngredientsDto.Response;

namespace WebApi.Models.DishesDto.Response
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string? Image { get; set; }
        public IEnumerable<DishIngridientDto> DishIngridients { get; set; }
    }
}
