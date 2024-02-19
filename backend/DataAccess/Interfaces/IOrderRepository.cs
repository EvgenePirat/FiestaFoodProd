using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken ct);
    }
}
