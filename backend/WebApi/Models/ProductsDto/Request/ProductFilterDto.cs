using WebApi.Models.Enums;
using WebApi.Models.FiltersDto;
using WebApi.Models.PaginationsDto;

namespace WebApi.Models.ProductsDto.Request
{
    public class ProductFilterDto
    {
        public OrderByDestination? OrderByDestination { get; set; }
        public PriceRangeDto? PriceRange { get; set; }
        public PaginationDto? Pagination { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<string>? BrandName { get; set; }
    }
}
