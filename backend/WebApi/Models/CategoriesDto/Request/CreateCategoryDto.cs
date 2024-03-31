using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.CategoriesDto.Request
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
