using Business.Models.Enums;
using Business.Models.Quantity.Request;

namespace Business.Models.Ingredients.Request
{
    public class UpdateIngredientModel
    {
        public string Title { get; set; }
        public UpdateQuantityModel Quantity { get; set; }
    }
}
