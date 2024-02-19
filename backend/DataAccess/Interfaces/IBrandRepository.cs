using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface IBrandRepository : IRepositoryBase<Brand>
    {
        Task<Brand?> GetById(Guid id, CancellationToken ct);
    }
}
