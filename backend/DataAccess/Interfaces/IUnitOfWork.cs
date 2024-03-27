using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IDishRepository DishRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IIngredientRepository IngredientsRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IDishIngredientRepository DishIngredientRepository { get; }
        Task SaveAsync(CancellationToken ct);
        Task<IDbContextTransaction> BeginTransactionDbContextAsync(CancellationToken ct);
    }
}
