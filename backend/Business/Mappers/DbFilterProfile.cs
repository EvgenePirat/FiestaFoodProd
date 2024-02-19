using AutoMapper;
using Business.Models.Filter;
using DataAccess.Utilities;

namespace Business.Mappers
{
    public class DbFilterProfile : Profile
    {
        public DbFilterProfile()
        {
            CreateMap<FilterModel, FilterState>();
            CreateMap<GridFilterModel, GridFilterState>();
        }
    }
}
