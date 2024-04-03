using AutoMapper;
using Business.Models.Dishes.Request;
using Business.Models.Dishes.Response;
using Business.Models.Pagination;
using WebApi.Models.DishesDto.Request;
using WebApi.Models.DishesDto.Response;
using WebApi.Models.PaginationsDto;

namespace WebApi.Mappers
{
    public class DishDtoProfile : Profile
    {
        public DishDtoProfile()
        {
            CreateMap<AddDishDto, AddDishModel>();
            CreateMap<DishModel, DishDto>();
            CreateMap<PaginationDto, PaginationModel>();
            CreateMap<UpdateDishDto, UpdateDishModel>();
            CreateMap<PagedDishModel, PagedDishDto>();
        }
    }
}
