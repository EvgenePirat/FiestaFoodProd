
using WebApi.Models.Enums;
using WebApi.Models.QuantitiesDto.Response;

namespace WebApi.Models.IngredientsDto.Response
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuantityDto Quantity { get; set; }
    }
}
