using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.CategoriesDto.Request
{
    public class UpdateCategoryDto
    {
        public string Title { get; set; }

        public IFormFile? FormFile { get; set; }
    }
}
