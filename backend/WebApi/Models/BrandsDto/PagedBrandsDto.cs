namespace WebApi.Models.BrandsDto
{
    public class PagedBrandsDto
    {
        public IEnumerable<BrandDto> Brands { get; set; }
        public int TotalPages { get; set; }
    }
}
