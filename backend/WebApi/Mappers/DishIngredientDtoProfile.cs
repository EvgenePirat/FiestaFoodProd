using AutoMapper;
using Business.Models.DishIngredients.Request;
using Business.Models.DishIngredients.Response;
using WebApi.Models.DishIngredientsDto.Request;
using WebApi.Models.DishIngredientsDto.Response;

namespace WebApi.Mappers
{
    public class DishIngredientDtoProfile : Profile
    {
        public DishIngredientDtoProfile()
        {
            CreateMap<CreateDishIngridientDto, CreateDishIngridientModel>();
            CreateMap<DishIngredientModel, DishIngredientDto>();
            CreateMap<UpdateDishIngredientDto, UpdateDishIngredientModel>();
        }
    }
}
