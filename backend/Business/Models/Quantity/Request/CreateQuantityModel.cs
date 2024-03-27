using Business.Models.Enums;

namespace Business.Models.Quantity.Request
{
    public class CreateQuantityModel
    {
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
    }
}
