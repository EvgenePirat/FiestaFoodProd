using Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DishesDto.Request
{
    public class UpdateDishDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
    }
}
