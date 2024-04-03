using Business.Models.Enums;

namespace Business.Models.Quantity.Response
{
    public class QuantityModel
    {
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
        public double MinCount { get; set; }
    }
}
