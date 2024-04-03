using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(StContext context) : base(context)
        {
        }

        public async Task<Ingredient?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Ingredients.Include(i => i.Quantity).FirstOrDefaultAsync(u => u.Id == id, cancellationToken: ct);
        }

        public async Task<Ingredient?> GetByNameAsync(string name, CancellationToken ct)
        {
            return await _context.Ingredients.Include(i => i.Quantity).FirstOrDefaultAsync(u => u.Title == name, cancellationToken: ct);
        }
    }
}
