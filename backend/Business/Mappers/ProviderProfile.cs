using AutoMapper;
using Business.Models.Providers;
using Entities.Entities;

namespace Business.Mappers
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<CreateProviderModel, Provider>();
            CreateMap<Provider, ProviderModel>();
            CreateMap<Provider, ProviderModel>().ReverseMap();
        }
    }
}
