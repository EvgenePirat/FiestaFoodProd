using Business.Models.Enums;
using Business.Models.Quantity.Response;

namespace Business.Models.Ingredients.Response
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
