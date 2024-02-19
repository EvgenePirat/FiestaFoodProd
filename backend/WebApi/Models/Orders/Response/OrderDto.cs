using WebApi.Models.CustomerInfosDto.Response;
using WebApi.Models.OrderDetails.Response;
using WebApi.Models.ProductsDto.Response;

namespace WebApi.Models.Orders.Response
{
    public class OrderDto
    {
        public CustomerInfoDto CustomerInfo { get; set; }
        public double Price { get; set; }
        public OrderDetailDto OrderDetail { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
