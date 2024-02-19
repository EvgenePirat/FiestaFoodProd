using Entities.Interfaces;

namespace Entities.Entities
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Kilograms { get; set; }
    }
}
