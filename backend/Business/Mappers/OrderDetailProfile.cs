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
            CreateMap<CreateOrderDetailModel, OrderDetail>();
            CreateMap<UpdateOrderDetailModel, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailModel>();
        }
    }
}
