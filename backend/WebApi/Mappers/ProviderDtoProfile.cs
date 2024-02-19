using AutoMapper;
using Business.Models.Providers;
using WebApi.Models.ProvidersDto;

namespace WebApi.Mappers
{
    public class ProviderDtoProfile : Profile
    {
        public ProviderDtoProfile()
        {
            CreateMap<CreateProviderDto, CreateProviderModel>();
            CreateMap<ProviderDto, ProviderModel>();
            CreateMap<ProviderDto, ProviderModel>().ReverseMap();
            CreateMap<PagedProviders, PagedProviderDto>();
            CreateMap<UpdateProviderDto, UpdateProviderModel>();
        }
    }
}
