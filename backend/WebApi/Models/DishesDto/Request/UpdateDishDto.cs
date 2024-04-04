using Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DishesDto.Request
{
    public class UpdateDishDto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
    }
}
