using Business.Models.Enums;

namespace Business.Models.Quantity.Request
{
    public class UpdateQuantityModel
    {
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
        public double MinCount { get; set; }
    }
}
