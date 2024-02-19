using Microsoft.AspNetCore.Http;

namespace Business.Models.Products
{
    public class UpdateProductModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Price { get; set; }
        public int CategoryId { get; set; }
        public Guid? ProviderId { get; set; }
        public Guid? BrandId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
    }
}
