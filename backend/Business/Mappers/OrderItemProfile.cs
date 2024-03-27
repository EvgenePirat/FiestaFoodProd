using AutoMapper;
using Business.Models.OrderItems.Request;
using Business.Models.OrderItems.Response;
using Entities.Entities;

namespace Business.Mappers
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<CreateOrderItemModel, OrderItem>();
            CreateMap<OrderItem, OrderItemModel>();
        }
    }
}
