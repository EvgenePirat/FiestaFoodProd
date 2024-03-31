using Microsoft.AspNetCore.Http;

namespace Business.Models.Dishes
{
    public class UpdateDishModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }
    }
}
