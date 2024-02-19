namespace Business.Models.Orders.Response
{
    public class PagedOrdersModel
    {
        public IEnumerable<OrderModel> Orders { get; set; }
        public int TotalPages { get; set; }
    }
}
