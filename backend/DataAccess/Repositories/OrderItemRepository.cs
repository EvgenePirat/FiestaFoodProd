using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(StContext context) : base(context)
        {
        }

        public async Task<OrderItem?> GetByIdAsync(Guid orderId, int dishId, CancellationToken ct)
        {
            return await _context.OrderItems
                .Include(u => u.Dish)
                .FirstOrDefaultAsync(u => u.OrderId == orderId && u.DishId == dishId, ct);
        }
    }
}
