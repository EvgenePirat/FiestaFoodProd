using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(StContext context) : base(context)
        {
        }

        public async Task<OrderDetail?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.Id == id, cancellationToken: ct);
        }
    }
}
