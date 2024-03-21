using WebApi.Models.Enums;

namespace WebApi.Models.QuantitiesDto.Request
{
    public class UpdateQuantityDto
    {
        public int Id { get; set; }
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
    }
}
