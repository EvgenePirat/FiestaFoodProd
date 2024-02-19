using Business.Models.Filter;
using Business.Models.Pagination;
using Business.Models.Products;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel> AddProductAsync(AddProductModel model, CancellationToken ct);

        Task<ProductModel> GetProductByIdAsync(Guid id, CancellationToken ct);

        Task<PagedProductModel> GetProductsByCategoryAsync(int categoryId, PaginationModel pagination, CancellationToken ct);

        Task<PagedProductModel> GetFilteredProductsAsync(FilterModel filter, CancellationToken ct);

        Task<ProductModel> UpdateProductAsync(UpdateProductModel model, CancellationToken ct);

        Task DeleteProductByIdAsync(Guid id, CancellationToken ct);
    }
}
