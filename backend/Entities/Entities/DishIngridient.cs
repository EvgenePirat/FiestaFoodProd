namespace Entities.Entities
{
    public class DishIngridient
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Count { get; set; }
    }
}
