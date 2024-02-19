using DataAccess.Utilities;
using Entities.Entities;
using Entities.Pagination;

namespace DataAccess.Interfaces
{
    public interface IDishRepository : IRepositoryBase<Dish>
    {

        /// <summary>
        /// Method for get Dish with id from db
        /// </summary>
        /// <returns>returned Dish with data if exist or null</returns>
        Task<Dish?> GetDishById(int id, CancellationToken ct);

        Task<PaginationResult<Dish>> GetDishesByQueryAsync(FilterState filter, CancellationToken ct);

        Task<PaginationResult<Dish>> GetDishByCategory(int categoryId, PaginationDb pagination, CancellationToken ct);

        Task<IEnumerable<Dish>> GetDishesByIds(IEnumerable<int> dishIds, CancellationToken ct);
    }
}
