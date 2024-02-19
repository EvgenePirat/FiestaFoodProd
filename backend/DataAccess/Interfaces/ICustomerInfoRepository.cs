using Entities.Entities;

namespace DataAccess.Interfaces
{
    public interface ICustomerInfoRepository : IRepositoryBase<CustomerInfo>
    {
        Task<CustomerInfo?> GetCustomerInfoById(Guid id, CancellationToken ct);
    }
}
