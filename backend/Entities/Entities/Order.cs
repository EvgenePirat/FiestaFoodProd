using Entities.Enums;
using Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Order : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderFinishedDate { get; set; }

    }
}
