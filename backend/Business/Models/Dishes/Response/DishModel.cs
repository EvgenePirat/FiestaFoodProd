using Business.Models.Categories.Response;
using Business.Models.DishIngredients.Response;

namespace Business.Models.Dishes.Response
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string? Image { get; set; }
        public IEnumerable<DishIngridientModel> DishIngridients { get; set; }
    }
}
