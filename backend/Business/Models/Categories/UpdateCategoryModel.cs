using Microsoft.AspNetCore.Http;

namespace Business.Models.Categories
{
    public class UpdateCategoryModel
    {
        public string CategoryName { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
