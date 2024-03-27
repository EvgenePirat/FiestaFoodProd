using System.ComponentModel.DataAnnotations;

namespace Business.Models.OrderItems.Request
{
    public class CreateOrderItemModel
    {
        public int DishId { get; set; }
        public int Count { get; set; }
        public string? Comment { get; set; }
    }
}
