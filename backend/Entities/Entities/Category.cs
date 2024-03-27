using Entities.Interfaces;

namespace Entities.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string PhotoPaths { get; set; }
    }
}
    