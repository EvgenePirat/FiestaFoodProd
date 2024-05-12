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
            CreateMap<CreateDishIngridientDto, CreateDishIngridientModel>()
                .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.Id));

            CreateMap<DishIngredientModel, DishIngredientDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId));

            CreateMap<UpdateDishIngredientDto, UpdateDishIngredientModel>()
                .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
