using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IBrandRepository BrandRepository { get; }
        IProviderRepository ProviderRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICustomerInfoRepository CustomerInfoRepository { get; }
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        Task SaveAsync(CancellationToken ct);
        Task<IDbContextTransaction> BeginTransactionDbContextAsync(CancellationToken ct);
    }
}
