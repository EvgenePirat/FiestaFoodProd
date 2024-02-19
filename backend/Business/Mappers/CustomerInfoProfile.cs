using AutoMapper;
using Business.Models.CustomerInfos.Request;
using Business.Models.CustomerInfos.Response;
using Entities.Entities;
using Entities.Pagination;

namespace Business.Mappers
{
    public class CustomerInfoProfile : Profile
    {
        public CustomerInfoProfile()
        {
            CreateMap<CreateCustomerInfoModel, CustomerInfo>();
            CreateMap<CustomerInfoModel, CustomerInfo>();
            CreateMap<CustomerInfoModel, CustomerInfo>().ReverseMap();
            CreateMap<UpdateCustomerInfoModel, CustomerInfo>();

            CreateMap<PaginationResult<CustomerInfo>, PagedCustomerInfoModel>()
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
                .ForMember(dest => dest.CustomerInfos, opt => opt.MapFrom(src => src.Result));
        }
    }
}
