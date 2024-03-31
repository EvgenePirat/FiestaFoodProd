using AutoMapper;
using Business.Models.OrderDetails.Request;
using Business.Models.OrderDetails.Response;
using WebApi.Models.OrderDetails.Request;
using WebApi.Models.OrderDetails.Response;

namespace WebApi.Mappers
{
    public class OrderDetailDtoProfile : Profile
    {
        public OrderDetailDtoProfile()
        {
            CreateMap<CreateOrderDetailDto, CreateOrderDetailModel>();
            CreateMap<OrderDetailModel, OrderDetailDto>();
        }
    }
}
