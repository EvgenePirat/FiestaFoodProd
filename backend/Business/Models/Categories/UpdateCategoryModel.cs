namespace Business.Models.Categories
{
    public class UpdateCategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
