using AutoMapper;
using Business.Models.DishIngredients.Request;
using Business.Models.DishIngredients.Response;
using Entities.Entities;

namespace Business.Mappers
{
    public class DishIngredientProfile : Profile
    {
        public DishIngredientProfile()
        {
            CreateMap<CreateDishIngridientModel, DishIngridient>();
            CreateMap<DishIngridient, DishIngridientModel>();
        }
    }
}
