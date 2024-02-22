using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface IIngredientsRepository : IRepositoryBase<Ingredient>
    {
        Task UpdateIngredients(IEnumerable<Ingredient> ingredients, CancellationToken ct);
    }
}
