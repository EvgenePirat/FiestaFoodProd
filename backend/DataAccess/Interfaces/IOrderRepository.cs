using DataAccess.Utilities;
using Entities.Entities;
using Entities.Pagination;

namespace DataAccess.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken ct);

        Task<PaginationResult<Order>> GetAllOrdersPagination(PaginationDb pagination, CancellationToken ct);
    }
}
