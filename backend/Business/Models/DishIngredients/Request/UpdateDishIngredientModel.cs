using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.DishIngredients.Request
{
    public class UpdateDishIngredientModel
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public double Count { get; set; }
    }
}
