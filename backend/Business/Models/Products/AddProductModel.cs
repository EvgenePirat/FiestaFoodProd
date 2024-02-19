using Microsoft.AspNetCore.Http;

namespace Business.Models.Products
{
    public class AddProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Guid? ProviderId { get; set; }
        public Guid? BrandId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
    }
}
