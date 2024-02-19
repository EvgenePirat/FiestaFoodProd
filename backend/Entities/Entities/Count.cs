using Entities.Interfaces;

namespace Entities.Entities
{
    public class Count : IEntity
    {
        public Guid Id { get; set; }
        public ulong ItemCount { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid? ProviderId { get; set; }
        public virtual Provider? Provider { get; set; }
    }
}
