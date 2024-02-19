using Business.Models.CustomerInfos.Response;
using Business.Models.OrderDetails.Response;
using Business.Models.Products;

namespace Business.Models.Orders.Response
{
    public class OrderModel
    {
        public Guid CustomerInfoId { get; set; }
        public CustomerInfoModel CustomerInfo { get; set; }
        public double Price { get; set; }
        public OrderDetailModel OrderDetail { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
