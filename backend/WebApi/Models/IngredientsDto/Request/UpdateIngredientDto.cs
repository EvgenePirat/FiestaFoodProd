
using WebApi.Models.Enums;
using WebApi.Models.QuantitiesDto.Request;

namespace WebApi.Models.IngredientsDto.Request
{
    public class UpdateIngredientDto
    {
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public UpdateQuantityDto Quantity { get; set; }
    }
}
