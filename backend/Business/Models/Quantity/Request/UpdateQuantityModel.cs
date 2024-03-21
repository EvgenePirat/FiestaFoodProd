using Business.Models.Enums;

namespace Business.Models.Quantity.Request
{
    public class UpdateQuantityModel
    {
        public int Id { get; set; }
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
    }
}
