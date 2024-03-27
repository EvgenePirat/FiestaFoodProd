using Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.OrdemItems.Request
{
    public class CreateOrderItemDto
    {
        [Required]
        public int DishId { get; set; }
        [Required]
        public int Count { get; set; }
        public string? Comment { get; set; }
    }
}
