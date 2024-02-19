namespace Business.Models.Users.Response
{
    public class PagedUsersModel
    {
        public IEnumerable<UserModel> Users { get; set; }
        public int TotalPages { get; set; }
    }
}
