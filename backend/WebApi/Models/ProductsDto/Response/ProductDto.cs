using WebApi.Models.BrandsDto;
using WebApi.Models.ProvidersDto;

namespace WebApi.Models.ProductsDto.Response
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public ProviderDto? Provider { get; set; }
        public BrandDto? Brand { get; set; }
        public string PhotoPaths { get; set; }
    }
}
