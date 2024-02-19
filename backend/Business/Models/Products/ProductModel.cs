using Business.Models.Brands;
using Business.Models.Categories;
using Business.Models.Providers;

namespace Business.Models.Products
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CategoryModel Category { get; set; }
        public ProviderModel? Provider { get; set; }
        public BrandModel? Brand { get; set; }
        public string PhotoPaths { get; set; }
    }
}
