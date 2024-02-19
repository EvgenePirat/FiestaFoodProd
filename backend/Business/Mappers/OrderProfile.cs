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
            CreateMap<UpdateOrderModel, Order>();
            CreateMap<Order, OrderModel>();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<CreateOrderDetailModel, OrderDetail>();
            CreateMap<UpdateOrderDetailModel, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailModel>();
        }
    }
}
