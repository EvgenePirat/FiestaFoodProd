using AutoMapper;
using Business.Models.Brands;
using Entities.Entities;

namespace Business.Mappers
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandModel, Brand>();
            CreateMap<BrandModel, Brand>().ReverseMap();

            CreateMap<UpdateBrandModel, Brand>();
            CreateMap<CreateBrandModel, Brand>();
        }
    }
}
