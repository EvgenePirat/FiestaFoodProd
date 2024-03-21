using System.ComponentModel.DataAnnotations;
using WebApi.Models.Enums;

namespace WebApi.Models.QuantitiesDto.Request
{
    public class CreateQuantityDto
    {

        [Required(ErrorMessage = "Measurement must be")]
        public Measurement Measurement { get; set; }

        [Required(ErrorMessage = "Count must be")]
        public double Count { get; set; }
    }
}
