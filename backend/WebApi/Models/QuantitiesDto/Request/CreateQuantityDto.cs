using System.ComponentModel.DataAnnotations;
using WebApi.Models.Enums;

namespace WebApi.Models.QuantitiesDto.Request
{
    public class CreateQuantityDto
    {
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
        public double MinCount { get; set; }
    }
}
