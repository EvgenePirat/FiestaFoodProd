using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using Entities.Pagination;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(StContext context) : base(context)
        {
        }

        /// <summary>
        /// Implementation logic for get product with id from db
        /// </summary>
        /// <param name="id">guid if</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Product</returns>
        public async Task<Product?> GetProductById(Guid id, CancellationToken ct)
        {
            return await _context.Products.FirstOrDefaultAsync(temp => temp.Id == id, cancellationToken: ct);
        }

        public async Task<PaginationResult<Product>> GetProductsByQueryAsync(FilterState filter, CancellationToken ct)
        {
            var query = _context.Products.OrderByState(filter).ToPagedListAsync(filter);
            double count = await _context.Products.CountAsync(cancellationToken: ct);
            return new PaginationResult<Product>
            {
                Result = await query.ToListAsync(ct),
                TotalPages = (int)Math.Ceiling(count / (int)filter.PageSize)
            };
        }

        public async Task<PaginationResult<Product>> GetProductByCategory(int categoryId, PaginationDb model, CancellationToken ct)
        {
            var query = _context.Products.Where(u => u.CategoryId == categoryId).ToPagedListAsync(model);
            double count = await _context.Products.CountAsync(cancellationToken: ct);
            return new PaginationResult<Product>
            {
                Result = await query.ToListAsync(ct),
                TotalPages = (int)Math.Ceiling(count / (int)model.PageSize)
            };
        }

        public async Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<Guid> productIds, CancellationToken ct)
        {
            return await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync(ct);
        }
    }
}
