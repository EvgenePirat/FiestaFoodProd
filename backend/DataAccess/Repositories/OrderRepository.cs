using Azure;
using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using Entities.Pagination;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(StContext context) : base(context)
        {
        }

        public async Task<PaginationResult<Order>> GetAllOrdersPagination(PaginationDb pagination, CancellationToken ct)
        {
            var query = _context.Orders.IncludeAll().AsNoTracking();
            double count = await _context.Orders.CountAsync(cancellationToken: ct);

            return new PaginationResult<Order>
            {
                Result = await query.Skip((pagination.PageNumber-1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync(ct),
                TotalPages = (int)Math.Ceiling(count / pagination.PageSize)
            };
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Orders
                .Include(u=> u.OrderDetail)
                .Include(ord => ord.OrderItems)
                .FirstOrDefaultAsync(od => od.Id == id, cancellationToken: ct);
        }
    }
}
