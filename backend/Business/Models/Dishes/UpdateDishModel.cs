using Microsoft.AspNetCore.Http;

namespace Business.Models.Dishes
{
    public class UpdateDishModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
    }
}
