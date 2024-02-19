using Business.Models.OrderDetails.Request;
using Business.Models.OrderDetails.Response;

namespace Business.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetailModel> CreateOrderDetailAsync(CreateOrderDetailModel model, CancellationToken ct);
        Task<OrderDetailModel> UpdateOrderDetailAsync(UpdateOrderDetailModel model, CancellationToken ct);
        Task DeleteOrderDetailByIdAsync(Guid id, CancellationToken ct);
        Task<OrderDetailModel> GetOrderDetailAsyncById(Guid id, CancellationToken ct);
        Task<OrderDetailModel> UpdateOrderDetailState(UpdateOrderDetailStateModel model, CancellationToken ct);
    }
}
