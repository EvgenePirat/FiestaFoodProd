using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<Category?> GetByIdAsync(int id, CancellationToken ct);
        Task<Category?> FindByCategoryNameAsync(string name, CancellationToken ct);
    }
}
