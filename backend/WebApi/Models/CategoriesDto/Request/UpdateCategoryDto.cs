namespace WebApi.Models.CategoriesDto.Request
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
