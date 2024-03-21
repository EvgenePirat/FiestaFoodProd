using AutoMapper;
using Business.Models.Ingredients.Request;
using Business.Models.Ingredients.Response;
using WebApi.Models.IngredientsDto.Request;
using WebApi.Models.IngredientsDto.Response;

namespace WebApi.Mappers
{
    public class IngredientDtoProfile : Profile
    {
        public IngredientDtoProfile()
        {
            CreateMap<CreateIngredientDto, CreateIngredientModel>();
            CreateMap<UpdateIngredientDto,  UpdateIngredientModel>();
            CreateMap<IngredientModel, IngredientDto>();
        }
    }
}
