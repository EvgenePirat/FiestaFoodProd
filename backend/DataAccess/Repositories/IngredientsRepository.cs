using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;

namespace DataAccess.Repositories
{
    public class IngredientsRepository : RepositoryBase<Ingredient>, IIngredientsRepository
    {
        public IngredientsRepository(StContext context) : base(context)
        {
        }

        public async Task UpdateIngredients(IEnumerable<Ingredient> ingredients, CancellationToken ct)
        {
            _context.Ingredients.AddRange(ingredients);
        }
    }
}
