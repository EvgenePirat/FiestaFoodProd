using Business.Models.Enums;
using Business.Models.Users.Response;
using System.ComponentModel.DataAnnotations;

namespace Business.Models.CustomerInfos.Request
{
    public class UpdateCustomerInfoModel
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public PostType PostType { get; set; }
        public string PostAddress { get; set; }
        public string Email { get; set; }
        public Guid? UserId { get; set; }
    }
}
