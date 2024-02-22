using Business.Models.CustomerInfos.Request;
using Business.Models.OrderDetails.Request;

namespace Business.Models.Orders.Request
{
    public class CreateOrderModel
    {
        public Guid? CustomerInfoId { get; set; }
        public CreateCustomerInfoModel? CustomerInfo { get; set; }
        public CreateOrderDetailModel OrderDetail { get; set; }
        public IEnumerable<int> DishesId { get; set; }
    }
}
