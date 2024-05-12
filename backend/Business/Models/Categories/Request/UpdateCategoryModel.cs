using Microsoft.AspNetCore.Http;

namespace Business.Models.Categories.Request
{
    public class UpdateCategoryModel
    {
        public string Title { get; set; }
        public IFormFile? File { get; set; }
    }
}
