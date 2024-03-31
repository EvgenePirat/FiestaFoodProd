using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Response
{
    public class OrderDetailDto
    {
        public double Sum { get; set; }
        public double EntryValue { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
