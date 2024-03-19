using AutoMapper;
using Business.Models.OrderDetails.Request;
using Business.Models.OrderDetails.Response;
using Entities.Entities;

namespace Business.Mappers
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<CreateOrderDetailModel, OrderItem>();
            CreateMap<UpdateOrderDetailModel, OrderItem>();
            CreateMap<OrderDetailModel, OrderItem>();
            CreateMap<OrderDetailModel, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderDetailStateModel, OrderItem>();
        }
    }
}
