namespace Business.Models.Providers
{
    public class PagedProviders
    {
        public int TotalPages { get; set; }
        public IEnumerable<ProviderModel> Providers { get; set; }
    }
}
