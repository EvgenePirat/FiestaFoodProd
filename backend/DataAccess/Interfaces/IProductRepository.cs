using DataAccess.Utilities;
using Entities.Entities;
using Entities.Pagination;

namespace DataAccess.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {

        /// <summary>
        /// Method for get product with id from db
        /// </summary>
        /// <returns>returned product with data if exist or null</returns>
        Task<Product?> GetProductById(Guid id, CancellationToken ct);

        Task<PaginationResult<Product>> GetProductsByQueryAsync(FilterState filter, CancellationToken ct);

        Task<PaginationResult<Product>> GetProductByCategory(int categoryId, PaginationDb pagination, CancellationToken ct);

        Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<Guid> productIds, CancellationToken ct);
    }
}
