using Business.Models.Ingredients.Response;

namespace Business.Models.DishIngredients.Response
{
    public class DishIngridientModel
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public double Count { get; set; }
    }
}
