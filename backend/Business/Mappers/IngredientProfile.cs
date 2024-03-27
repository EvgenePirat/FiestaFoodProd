using AutoMapper;
using Business.Models.Ingredients.Request;
using Business.Models.Ingredients.Response;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<CreateIngredientModel, Ingredient>();
            CreateMap<UpdateIngredientModel, Ingredient>();
            CreateMap<Ingredient, IngredientModel>();
        }
    }
}
