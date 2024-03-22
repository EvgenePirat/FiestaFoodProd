namespace Business.Models.DishIngredients.Request
{
    public class CreateDishIngridientModel
    {
        public int DishId { get; set; } = 0;
        public int IngredientId { get; set; }
        public double Count { get; set; }
    }
}
