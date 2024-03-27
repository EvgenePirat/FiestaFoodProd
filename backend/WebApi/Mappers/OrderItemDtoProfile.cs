using AutoMapper;
using Business.Models.OrderItems.Request;
using Business.Models.OrderItems.Response;
using WebApi.Models.OrdemItems.Request;
using WebApi.Models.OrdemItems.Response;

namespace WebApi.Mappers
{
    public class OrderItemDtoProfile : Profile
    {
        public OrderItemDtoProfile()
        {
            CreateMap<CreateOrderItemDto, CreateOrderItemModel>();
            CreateMap<OrderItemModel, OrderItemDto>();
        }
    }
}
