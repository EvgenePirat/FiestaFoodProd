namespace Business.Models.Users.Request
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}
