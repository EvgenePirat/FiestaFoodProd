using DataAccess.Utilities;
using Entities.Interfaces;
using Entities.Pagination;

namespace DataAccess.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        void Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        Task<PaginationResult<TEntity>> GetPagedAsync(PaginationDb pagination, CancellationToken ct);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<PaginationResult<TEntity>> GetPagedByQueryAsync(FilterState filter, CancellationToken ct);
    }
}
