using Business.Models.CustomerInfos.Request;

namespace Business.Models.Users.Request
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public UpdateCustomerInfoModel? CustomerInfoModel { get; set; }
    }
}
