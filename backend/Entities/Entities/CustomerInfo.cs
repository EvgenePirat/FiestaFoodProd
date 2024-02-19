using Entities.Enums;
using Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class CustomerInfo : IEntity
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string? Address { get; set; }

        [StringLength(13, MinimumLength = 13)]
        public string PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 4)]
        public string City { get; set; }

        public PostType PostType { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string PostAddress { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Email { get; set; }

        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
