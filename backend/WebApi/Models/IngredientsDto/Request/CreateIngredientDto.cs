using WebApi.Models.Enums;
using WebApi.Models.QuantitiesDto.Request;

namespace WebApi.Models.IngredientsDto.Request
{
    public class CreateIngredientDto
    {
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public CreateQuantityDto Quantity { get; set; }
    }
}
