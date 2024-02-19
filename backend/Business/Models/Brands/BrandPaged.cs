namespace Business.Models.Brands
{
    public class BrandPaged
    {
        public int TotalPages { get; set; }
        public IEnumerable<BrandModel> Brands { get; set; }
    }
}
