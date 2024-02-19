using AutoMapper;
using Business.Models.Brands;
using Business.Models.Pagination;
using WebApi.Models.BrandsDto;
using WebApi.Models.PaginationsDto;

namespace WebApi.Mappers
{
    public class BrandDtoProfile : Profile
    {
        public BrandDtoProfile()
        {
            CreateMap<UpdateBrandDto, UpdateBrandModel>();

            CreateMap<BrandPaged, PagedBrandsDto>();

            CreateMap<BrandDto, CreateBrandModel>();

            CreateMap<BrandDto, BrandModel>();
            CreateMap<BrandDto, BrandModel>().ReverseMap();

            CreateMap<PaginationDto, PaginationModel>();
        }
    }
}
