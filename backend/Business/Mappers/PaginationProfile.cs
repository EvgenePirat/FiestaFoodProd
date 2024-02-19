using AutoMapper;
using Business.Models.Pagination;
using DataAccess.Utilities;

namespace Business.Mappers
{
    public class PaginationProfile : Profile
    {
        public PaginationProfile()
        {
            CreateMap<PaginationModel, PaginationDb>();
            CreateMap<PaginationModel, PaginationDb>().ReverseMap();
        }
    }
}
