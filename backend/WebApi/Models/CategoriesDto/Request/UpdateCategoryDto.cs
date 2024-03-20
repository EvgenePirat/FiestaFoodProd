using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.CategoriesDto.Request
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "Id must be in category")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name can`t be not null")]
        [MinLength(3, ErrorMessage = "Category name can more three chars")]
        public string CategoryName { get; set; }

        public IFormFile? FormFile { get; set; }
    }
}
