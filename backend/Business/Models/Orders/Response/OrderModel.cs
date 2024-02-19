using Business.Models.CustomerInfos.Response;
using Business.Models.Dishes;
using Business.Models.OrderDetails.Response;

namespace Business.Models.Orders.Response
{
    public class OrderModel
    {
        public Guid CustomerInfoId { get; set; }
        public CustomerInfoModel CustomerInfo { get; set; }
        public double Price { get; set; }
        public OrderDetailModel OrderDetail { get; set; }
        public IEnumerable<DishModel> Products { get; set; }
    }
}
