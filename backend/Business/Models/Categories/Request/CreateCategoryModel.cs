using Microsoft.AspNetCore.Http;

namespace Business.Models.Categories.Request
{
    public class CreateCategoryModel
    {
        public string Title { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
