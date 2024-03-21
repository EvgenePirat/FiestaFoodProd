using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface IIngredientRepository : IRepositoryBase<Ingredient>
    {
        Task<Ingredient?> GetByIdAsync(int id, CancellationToken ct);

        Task<Ingredient?> GetByNameAsync(string name, CancellationToken ct);
    }
}
