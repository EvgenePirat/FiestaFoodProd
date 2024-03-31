using Business.Models.Dishes;
using Business.Models.DishIngredients.Request;
using Business.Models.Filter;
using Business.Models.Pagination;

namespace Business.Interfaces
{
    public interface IDishService
    {
        Task<DishModel> AddDishAsync(AddDishModel model, CancellationToken ct);

        Task<DishModel> GetDishByIdAsync(int id, CancellationToken ct);

        Task<PagedDishModel> GetDishesByCategoryAsync(int categoryId, PaginationModel pagination, CancellationToken ct);

        Task<PagedDishModel> GetFilteredDishesAsync(FilterModel filter, CancellationToken ct);

        Task<DishModel> UpdateDishAsync(int id, UpdateDishModel model, CancellationToken ct);

        Task UpdateDishIngredientsForDishAsync(int dishId, List<UpdateDishIngredientModel> model, CancellationToken ct);

        Task DeleteDishByIdAsync(int id, CancellationToken ct);
    }
}
