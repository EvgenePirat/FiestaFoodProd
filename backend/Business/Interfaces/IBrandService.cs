using Business.Models.Brands;
using Business.Models.Pagination;

namespace Business.Interfaces
{
    public interface IBrandService
    {
        Task CreateBrandAsync(CreateBrandModel model, CancellationToken ct);
        Task<BrandModel> UpdateBrandAsync(UpdateBrandModel model, CancellationToken ct);
        Task DeleteBrandByIdAsync(Guid id, CancellationToken ct);
        Task<BrandPaged> GetBrandsPagedAsync(PaginationModel pagination, CancellationToken ct);
    }
}
