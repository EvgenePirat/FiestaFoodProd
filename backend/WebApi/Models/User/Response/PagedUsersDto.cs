namespace WebApi.Models.User.Response
{
    public class PagedUsersDto
    {
        public IEnumerable<UserDto> Users { get; set; }
        public int TotalPages { get; set; }
    }
}
