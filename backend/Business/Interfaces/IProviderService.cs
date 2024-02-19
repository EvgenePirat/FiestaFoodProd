using Business.Models.Pagination;
using Business.Models.Providers;

namespace Business.Interfaces
{
    public interface IProviderService
    {
        Task CreateProviderAsync(CreateProviderModel model, CancellationToken ct);
        Task<ProviderModel> GetProviderByProductAsync(Guid productId, CancellationToken ct);
        Task<ProviderModel> GetProviderByIdAsync(Guid providerId, CancellationToken ct);
        Task<PagedProviders> GetAllCompanyProvidersAsync(PaginationModel model, CancellationToken ct);
        Task<ProviderModel> UpdateProviderAsync(UpdateProviderModel model, CancellationToken ct);
        Task DeleteProviderAsync(Guid providerId, CancellationToken ct);
    }
}
