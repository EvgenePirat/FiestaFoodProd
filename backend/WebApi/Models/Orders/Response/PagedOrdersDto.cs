namespace WebApi.Models.Orders.Response
{
    public class PagedOrdersDto
    {
        public IEnumerable<OrderDto> Orders { get; set; }
        public int TotalPages { get; set; }
    }
}
