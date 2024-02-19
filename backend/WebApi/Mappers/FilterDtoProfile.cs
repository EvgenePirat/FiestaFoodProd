using AutoMapper;
using Business.Models.Filter;
using WebApi.Models.FiltersDto;

namespace WebApi.Mappers
{
    public class FilterDtoProfile : Profile
    {
        public FilterDtoProfile()
        {

            CreateMap<FilterDto, FilterModel>();
            CreateMap<GridFilterDto, GridFilterModel>();
        }
    }
}
