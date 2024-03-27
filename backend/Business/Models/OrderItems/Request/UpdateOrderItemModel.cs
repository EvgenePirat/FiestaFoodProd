using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.OrderItems.Request
{
    public class UpdateOrderItemModel
    {
        public int DishId { get; set; }
        public int Count { get; set; }
        public string? Comment { get; set; }
    }
}
