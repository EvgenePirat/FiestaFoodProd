using Entities.Interfaces;

namespace Entities.Entities
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid? ProviderId { get; set; }
        public virtual Provider? Provider { get; set; }
        public Guid? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public ulong? Article { get; set; }
        public string PhotoPaths { get; set; }
        public ulong? ColorId { get; set; }
        public virtual Color? Color { get; set; }
        public ulong? SizeId { get; set; }
        public virtual Size? Size { get; set; }
        public IEnumerable<Color>? ProductColors { get; set; }
    }
}
 