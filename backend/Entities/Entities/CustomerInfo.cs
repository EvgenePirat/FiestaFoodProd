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
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
