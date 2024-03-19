using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using Entities.Pagination;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DishRepository : RepositoryBase<Dish>, IDishRepository
    {
        public DishRepository(StContext context) : base(context)
        {
        }

        /// <summary>
        /// Implementation logic for get Dish with id from db
        /// </summary>
        /// <param name="id">guid if</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dish</returns>
        public async Task<Dish?> GetDishById(int id, CancellationToken ct)
        {
            return await _context.Dishes.FirstOrDefaultAsync(temp => temp.Id == id, cancellationToken: ct);
        }

        public async Task<PaginationResult<Dish>> GetDishesByQueryAsync(FilterState filter, CancellationToken ct)
        {
            var query = _context.Dishes.OrderByState(filter).ToPagedListAsync(filter);
            double count = await _context.Dishes.CountAsync(cancellationToken: ct);
            return new PaginationResult<Dish>
            {
                Result = await query.ToListAsync(ct),
                TotalPages = (int)Math.Ceiling(count / (int)filter.PageSize)
            };
        }

        public async Task<PaginationResult<Dish>> GetDishByCategory(int categoryId, PaginationDb model, CancellationToken ct)
        {
            var query = _context.Dishes.Where(u => u.CategoryId == categoryId).ToPagedListAsync(model);
            double count = await _context.Dishes.CountAsync(cancellationToken: ct);
            return new PaginationResult<Dish>
            {
                Result = await query.ToListAsync(ct),
                TotalPages = (int)Math.Ceiling(count / (int)model.PageSize)
            };
        }

        public async Task<IEnumerable<Dish>> GetDishesByIds(IEnumerable<int> DishIds, CancellationToken ct)
        {
            return await _context.Dishes
                .Where(p => DishIds.Contains(p.Id))
                .ToListAsync(ct);
        }
    }
}
