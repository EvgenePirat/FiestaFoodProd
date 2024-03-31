using Business.Models.Enums;
using Business.Models.Quantity.Request;

namespace Business.Models.Ingredients.Request
{
    public class UpdateIngredientModel
    {
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public UpdateQuantityModel Quantity { get; set; }
    }
}
