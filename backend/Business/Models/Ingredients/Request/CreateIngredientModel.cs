using Business.Models.Enums;
using Business.Models.Quantity.Request;
using Business.Models.Quantity.Response;

namespace Business.Models.Ingredients.Request
{
    public class CreateIngredientModel
    {
        public string Title { get; set; }
        public CreateQuantityModel Quantity { get; set; }
    }
}
