namespace WebApi.Models.ProductsDto.Response
{
    public class PagedProductDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int TotalPages { get; set; }
    }
}
