using Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Provider : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public string Email { get; set; }
        [StringLength(13, MinimumLength = 13)]
        public string PhoneNumber { get; set; }
        public string? AdditionalContact { get; set; }
    }
}
