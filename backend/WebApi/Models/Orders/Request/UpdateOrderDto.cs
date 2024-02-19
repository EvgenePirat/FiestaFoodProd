using WebApi.Models.CustomerInfosDto.Request;

namespace WebApi.Models.Orders.Request
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public UpdateCustomerInfoDto CustomerInfo { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
