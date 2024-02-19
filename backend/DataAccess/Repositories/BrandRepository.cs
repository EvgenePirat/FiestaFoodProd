using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(StContext context) : base(context)
        {
        }

        public async Task<Brand?> GetById(Guid id, CancellationToken ct)
        {
            return await _context.Brands.FirstOrDefaultAsync(u=> u.Id == id, cancellationToken: ct);
        }
    }
}
