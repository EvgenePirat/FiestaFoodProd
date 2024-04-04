using WebApi.Models.DishIngredientsDto.Request;

namespace WebApi.Models.DishesDto.Request
{
    public class AddDishDto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
        public List<CreateDishIngridientDto> DishIngridients { get; set; }
    }
}
