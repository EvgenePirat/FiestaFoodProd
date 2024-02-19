using AutoMapper;
using Business.Models.CustomerInfos.Request;
using Business.Models.CustomerInfos.Response;
using WebApi.Models.CustomerInfosDto.Request;
using WebApi.Models.CustomerInfosDto.Response;

namespace WebApi.Mappers
{
    public class CustomerInfoDtoProfile : Profile
    {
        public CustomerInfoDtoProfile()
        {
            CreateMap<CreateCustomerInfoDto, CreateCustomerInfoModel>();

            CreateMap<UpdateCustomerInfoDto,UpdateCustomerInfoModel>();

            CreateMap<CustomerInfoDto, CustomerInfoModel>();
            CreateMap<CustomerInfoDto, CustomerInfoModel>().ReverseMap();

            CreateMap<PagedCustomerInfoDto, PagedCustomerInfoModel>();
        }
    }
}
