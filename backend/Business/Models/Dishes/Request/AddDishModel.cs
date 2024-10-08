﻿using Business.Models.DishIngredients.Request;
using Business.Models.Ingredients.Response;
using Microsoft.AspNetCore.Http;

namespace Business.Models.Dishes.Request
{
    public class AddDishModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<CreateDishIngridientModel> DishIngridients { get; set; }
        public IFormFile? File { get; set; }
    }
}
