using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface IProviderRepository : IRepositoryBase<Provider>
    {
        Task<Provider?> GetByIdAsync(Guid id, CancellationToken ct);

        Task<Provider?> GetProviderByProductIdAsync(Guid productId, CancellationToken ct);
    }
}
