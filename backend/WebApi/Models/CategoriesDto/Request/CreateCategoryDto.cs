namespace WebApi.Models.CategoriesDto.Request
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
