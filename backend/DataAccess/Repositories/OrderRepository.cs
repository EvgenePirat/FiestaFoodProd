using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(StContext context) : base(context)
        {
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Orders
                .Include(u=> u.OrderDetail)
                .Include(ord => ord.CustomerInfo)
                .FirstOrDefaultAsync(od => od.Id == id, cancellationToken: ct);
        }
    }
}
