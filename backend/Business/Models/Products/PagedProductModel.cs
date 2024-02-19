namespace Business.Models.Products
{
    public class PagedProductModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public int TotalPages { get; set; }
    }
}
