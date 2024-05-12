using DataAccess.Utilities;
using Entities.Entities;
using Entities.Enums;
using Entities.Pagination;

namespace DataAccess.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken ct);

        Task<IEnumerable<Order>> GetAllByDateAndStateAsync(DateTime date, OrderState state, CancellationToken ct);

        Task<IEnumerable<Order>> GetAllByDateAsync(DateTime date, CancellationToken ct);

        Task<PaginationResult<Order>> GetAllOrdersPagination(PaginationDb pagination, CancellationToken ct);
    }
}
