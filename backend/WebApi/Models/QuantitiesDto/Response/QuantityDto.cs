using WebApi.Models.Enums;

namespace WebApi.Models.QuantitiesDto.Response
{
    public class QuantityDto
    {
        public int Id { get; set; }
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
    }
}
