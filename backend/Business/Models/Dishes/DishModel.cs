using Business.Models.Categories;
using Business.Models.DishIngredients.Response;

namespace Business.Models.Dishes
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CategoryModel Category { get; set; }
        public string PhotoPaths { get; set; }
        public IEnumerable<DishIngridientModel> DishIngridients { get; set; }
    }
}
