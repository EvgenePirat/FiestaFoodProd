namespace Business.Models.CustomerInfos.Response
{
    public class PagedCustomerInfoModel
    {
        public IEnumerable<CustomerInfoModel> CustomerInfos { get; set; }
        public int TotalPages { get; set; }
    }
}
