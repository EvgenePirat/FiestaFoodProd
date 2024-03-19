using WebApi.Models.DishesDto.Response;
using WebApi.Models.OrderDetails.Response;

namespace WebApi.Models.Orders.Response
{
    public class OrderDto
    {
        public double Price { get; set; }
        public OrderDetailDto OrderDetail { get; set; }
        public IEnumerable<DishDto> Products { get; set; }
    }
}
