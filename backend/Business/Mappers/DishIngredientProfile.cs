using AutoMapper;
using Business.Models.DishIngredients.Request;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class DishIngredientProfile : Profile
    {
        public DishIngredientProfile()
        {
            CreateMap<CreateDishIngridientModel, DishIngridient>();
        }
    }
}
