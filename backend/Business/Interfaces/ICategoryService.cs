using Business.Models.Categories.Request;
using Business.Models.Categories.Response;

namespace Business.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryModel> CreateCategoryAsync(CreateCategoryModel model, CancellationToken ct);
        Task<CategoryModel> UpdateCategoryAsync(int id, UpdateCategoryModel model, CancellationToken ct);
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync(CancellationToken ct);
        Task DeleteCategoryAsync(int id, CancellationToken ct);
    }
}
