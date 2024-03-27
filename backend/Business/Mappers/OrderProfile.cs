using AutoMapper;
using Business.Models.OrderDetails.Request;
using Business.Models.OrderDetails.Response;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;
using Entities.Entities;

namespace Business.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderModel, Order>();
            CreateMap<Order, OrderModel>();
        }
    }
}
