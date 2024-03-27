using Business.Models.Enums;
using Business.Models.Quantity.Request;
using Business.Models.Quantity.Response;

namespace Business.Models.Ingredients.Request
{
    public class CreateIngredientModel
    {
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public CreateQuantityModel Quantity { get; set; }
    }
}
