using AutoMapper;
using Business.Models.Dishes;
using Business.Models.Pagination;
using WebApi.Models.DishesDto.Request;
using WebApi.Models.DishesDto.Response;
using WebApi.Models.PaginationsDto;

namespace WebApi.Mappers
{
    public class ProductDtoProfile : Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<AddDishDto, AddDishModel>();
            CreateMap<DishModel, DishDto>();
            CreateMap<PaginationDto, PaginationModel>();
            CreateMap<UpdateDishDto, UpdateDishModel>();
            CreateMap<PagedDishModel, PagedDishDto>();
        }
    }
}
