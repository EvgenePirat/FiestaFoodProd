using WebApi.Models.Enums;

namespace WebApi.Models.QuantitiesDto.Response
{
    public class QuantityDto
    {
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
        public double MinCount { get; set; }
    }
}
