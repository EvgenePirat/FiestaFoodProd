using AutoMapper;
using Business.Models.Filter;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;
using WebApi.Models.FiltersDto;
using WebApi.Models.Orders.Request;
using WebApi.Models.Orders.Response;

namespace WebApi.Mappers
{
    public class OrderDtoProfile : Profile
    {
        public OrderDtoProfile()
        {
            CreateMap<CreateOrderDto, CreateOrderModel>();
            CreateMap<UpdateOrderDto, UpdateOrderModel>();
            CreateMap<OrderDto, OrderModel>();
            CreateMap<OrderDto, OrderModel>().ReverseMap();
            CreateMap<PagedOrdersModel, PagedOrdersDto>();
        }
    }
}
