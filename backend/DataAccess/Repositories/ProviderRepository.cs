using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(StContext context) : base(context)
        {
        }

        public async Task<Provider?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Providers.FirstOrDefaultAsync(u => u.Id == id, cancellationToken: ct);
        }

        public async Task<Provider?> GetProviderByProductIdAsync(Guid productId, CancellationToken ct)
        {
            return await _context.Products
                .Where(p => p.Id == productId)
                .Select(u => u.Provider)
                .FirstOrDefaultAsync(cancellationToken: ct);
        }
    }
}
