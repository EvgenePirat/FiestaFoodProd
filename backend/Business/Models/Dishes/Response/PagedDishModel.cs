﻿namespace Business.Models.Dishes.Response
{
    public class PagedDishModel
    {
        public IEnumerable<DishModel> Dishes { get; set; }
        public int TotalPages { get; set; }
    }
}
