using System.ComponentModel.DataAnnotations;
using Entities.Enums;
using Entities.Interfaces;

namespace Entities.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }
        public Role Role { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual IEnumerable<CustomerInfo> CustomerInfos { get; set; }
    }
}
