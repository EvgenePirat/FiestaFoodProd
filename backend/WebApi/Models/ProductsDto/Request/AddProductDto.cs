namespace WebApi.Models.ProductsDto.Request
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Guid? ProviderId { get; set; }
        public Guid? BrandId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
    }
}
