using AutoMapper;
using Business.Models.Quantity.Request;
using Business.Models.Quantity.Response;
using WebApi.Models.QuantitiesDto.Request;
using WebApi.Models.QuantitiesDto.Response;

namespace WebApi.Mappers
{
    public class QuantityDtoProfile : Profile
    {
        public QuantityDtoProfile()
        {
            CreateMap<CreateQuantityDto, CreateQuantityModel>();
            CreateMap<UpdateQuantityDto, UpdateQuantityModel>();
            CreateMap<QuantityModel, QuantityDto>();
        }
    }
}
