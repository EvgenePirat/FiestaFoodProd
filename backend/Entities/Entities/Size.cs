namespace Entities.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string SizeName { get; set; }
    }
}
