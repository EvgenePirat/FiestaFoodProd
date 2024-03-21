using WebApi.Models.Enums;
using WebApi.Models.QuantitiesDto.Response;

namespace WebApi.Models.IngredientsDto.Response
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public QuantityDto Quantity { get; set; }
    }
}
