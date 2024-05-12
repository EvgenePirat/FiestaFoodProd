using Business.Models.Enums;
using Business.Models.Filter;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;
using Business.Models.Pagination;

namespace Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> CreateOrderAsync(CreateOrderModel model, CancellationToken ct);

        Task<OrderModel> GetOrderByIdAsync(Guid id, CancellationToken ct);
        
        Task<PagedOrdersModel> GetFilteredOrdersAsync(FilterModel filter, CancellationToken ct);

        Task<PagedOrdersModel> GetAllOrdersAsync(PaginationModel pagination, CancellationToken ct);

        Task<IEnumerable<OrderModel>> GetOrdersByDateAndStatusAsync(DateTime date, OrderState state , CancellationToken ct);

        Task<IEnumerable<OrderModel>> GetOrdersByDateAsync(DateTime date, CancellationToken ct);

        Task<OrderModel> UpdateOrderAsync(Guid id, UpdateOrderModel model, CancellationToken ct);

        Task<OrderModel> UpdateOrderStateAsync(UpdateOrderStateModel model, CancellationToken ct);

        Task DeleteOrderByIdAsync(Guid id, CancellationToken ct);
    }
}
