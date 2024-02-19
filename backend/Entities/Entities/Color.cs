using Entities.Interfaces;

namespace Entities.Entities
{
    public class Color : IEntity
    {
        public ulong Id { get; set; }
        public string ColorName { get; set; }
        public string ColorHex { get; set; }
    }
}
