using WebApi.Models.Enums;

namespace WebApi.Models.QuantitiesDto.Request
{
    public class UpdateQuantityDto
    {
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
        public double MinCount { get; set; }
    }
}
