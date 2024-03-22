using AutoMapper;
using Business.Models.DishIngredients.Request;
using WebApi.Models.DishIngredientsDto.Request;

namespace WebApi.Mappers
{
    public class DishIngredientDtoProfile : Profile
    {
        public DishIngredientDtoProfile()
        {
            CreateMap<CreateDishIngridientDto, CreateDishIngridientModel>();
        }
    }
}
