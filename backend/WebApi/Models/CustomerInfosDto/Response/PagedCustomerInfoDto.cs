namespace WebApi.Models.CustomerInfosDto.Response
{
    public class PagedCustomerInfoDto
    {
        public IEnumerable<CustomerInfoDto> CustomerInfos { get; set; }
        public int TotalPages { get; set; }
    }
}
