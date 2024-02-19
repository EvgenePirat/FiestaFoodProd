using WebApi.Models.Enums;
using WebApi.Models.FiltersDto;
using WebApi.Models.PaginationsDto;

namespace WebApi.Models.DishesDto.Request
{
    public class DishFilterDto
    {
        public OrderByDestination? OrderByDestination { get; set; }
        public PriceRangeDto? PriceRange { get; set; }
        public PaginationDto? Pagination { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<string>? BrandName { get; set; }
    }
}
