using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        Task<OrderDetail?> GetByIdAsync(Guid id, CancellationToken ct);
    }
}
