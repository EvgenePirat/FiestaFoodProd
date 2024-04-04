using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(StContext context) : base(context)
        {
        }

        public async Task<Category?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Categories.FirstOrDefaultAsync(u => u.Id == id, cancellationToken: ct);
        }

        public async Task<Category?> FindByCategoryNameAsync(string name, CancellationToken ct)
        {
            return await _context.Categories.FirstOrDefaultAsync(u => u.Title == name, cancellationToken: ct);
        }
    }
}
