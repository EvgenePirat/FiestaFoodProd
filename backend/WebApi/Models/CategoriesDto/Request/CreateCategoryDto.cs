using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.CategoriesDto.Request
{
    public class CreateCategoryDto
    {
        public string Title { get; set; }
        public IFormFile? File { get; set; }
    }
}
