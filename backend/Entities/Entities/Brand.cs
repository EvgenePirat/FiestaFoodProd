using Entities.Interfaces;

namespace Entities.Entities
{
    public class Brand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
