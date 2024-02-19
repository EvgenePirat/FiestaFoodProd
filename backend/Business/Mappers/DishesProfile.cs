using AutoMapper;
using Business.Models.Dishes;
using Entities.Entities;

namespace Business.Mappers
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<AddDishModel, Dish>();
            CreateMap<Dish, DishModel>();
            CreateMap<UpdateDishModel, Dish>();
        }
    }
}
