using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Request
{
    public class CreateOrderDetailDto
    {
        public double EntryValue { get; set; }
        public double Sum { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
