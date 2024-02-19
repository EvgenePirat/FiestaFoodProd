namespace WebApi.Models.DishesDto.Response
{
    public class PagedDishDto
    {
        public IEnumerable<DishDto> Dishes { get; set; }
        public int TotalPages { get; set; }
    }
}
