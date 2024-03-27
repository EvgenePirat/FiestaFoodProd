using Business.Models.Categories;
using Business.Models.Ingredients.Request;
using Business.Models.Ingredients.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IIngredientService
    {
        Task<IngredientModel> CreateIngredientAsync(CreateIngredientModel model, CancellationToken ct);
        Task<IngredientModel> UpdateIngredientAsync(UpdateIngredientModel model, CancellationToken ct);
        Task<IEnumerable<IngredientModel>> GetAllIngredientsAsync(CancellationToken ct);
        Task DeleteIngredientAsync(int id, CancellationToken ct);
    }
}
