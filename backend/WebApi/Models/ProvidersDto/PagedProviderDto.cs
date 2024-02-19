namespace WebApi.Models.ProvidersDto
{
    public class PagedProviderDto
    {
        public IEnumerable<ProviderDto> Providers { get; set; }
        public int TotalPages { get; set; }
    }
}
