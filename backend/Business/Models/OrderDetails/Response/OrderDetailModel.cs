using Business.Models.Enums;
using Entities.Entities;

namespace Business.Models.OrderDetails.Response
{
    public class OrderDetailModel
    {
        public double Sum { get; set; }
        public double EntryValue { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
