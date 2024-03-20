namespace WebApi.Models.DishesDto.Response
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string? PhotoPaths { get; set; }
    }
}
