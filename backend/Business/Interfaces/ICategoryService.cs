using Business.Models.Categories;

namespace Business.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryModel> CreateCategoryAsync(CreateCategoryModel model, CancellationToken ct);
        Task<CategoryModel> UpdateCategoryAsync(UpdateCategoryModel model, CancellationToken ct);
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync(CancellationToken ct);
        Task DeleteCategoryAsync(int id, CancellationToken ct);
    }
}
