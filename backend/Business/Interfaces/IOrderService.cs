using Business.Models.Filter;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;

namespace Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> CreateOrderAsync(CreateOrderModel model, CancellationToken ct);

        Task<OrderModel> GetOrderByIdAsync(Guid id, CancellationToken ct);
        
        Task<PagedOrdersModel> GetFilteredOrdersAsync(FilterModel filter, CancellationToken ct);

        Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken ct);

        Task DeleteOrderByIdAsync(Guid id, CancellationToken ct);
    }
}
