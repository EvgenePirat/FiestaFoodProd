using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Response
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public OrderState OrderState { get; set; }
        public bool IsPaid { get; set; }
    }
}
