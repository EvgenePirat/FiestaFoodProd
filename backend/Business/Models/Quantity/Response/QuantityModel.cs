using Business.Models.Enums;

namespace Business.Models.Quantity.Response
{
    public class QuantityModel
    {
        public int Id { get; set; }
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
    }
}
