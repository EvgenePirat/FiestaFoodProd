using Entities.Interfaces;

namespace Entities.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
    