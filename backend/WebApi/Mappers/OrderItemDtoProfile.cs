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
            CreateMap<CreateOrderItemDto, CreateOrderItemModel>()
                .ForMember(dest => dest.DishId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdateOrderItemDto, UpdateOrderItemModel>()
                .ForMember(dest => dest.DishId, opt => opt.MapFrom(src => src.Id));

            CreateMap<OrderItemModel, OrderItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId));
        }
    }
}
