﻿using Entities.Enums;

namespace Entities.Entities
{
    public class Quantity
    {
        public int Id { get; set; }
        public Measurement Measurement { get; set; }
        public double Count { get; set; }
        public double MinCount { get; set; }
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
