using Business.Models.CustomerInfos.Request;
using Business.Models.CustomerInfos.Response;
using Business.Models.Filter;
using Business.Models.Pagination;

namespace Business.Interfaces
{
    public interface ICustomerInfoService
    {
        Task<CustomerInfoModel> CreateCustomerInfoAsync(CreateCustomerInfoModel model, CancellationToken ct);
        Task<PagedCustomerInfoModel> GetAllCustomerInfoAsync(PaginationModel model, CancellationToken ct);
        Task<CustomerInfoModel?> GetCustomerByIdAsync(Guid id, CancellationToken ct);
        Task<CustomerInfoModel> UpdateCustomerInfoAsync(UpdateCustomerInfoModel model, CancellationToken ct);
        Task<PagedCustomerInfoModel> GetCustomerInfosByFilter(FilterModel model, CancellationToken ct);
        Task DeleteCustomerInfoAsync(Guid id, CancellationToken ct);
    }
}
