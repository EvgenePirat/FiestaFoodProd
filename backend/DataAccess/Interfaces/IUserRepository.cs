using Entities.Entities;

namespace DataAccess.Interfaces
{
    /// <summary>
    /// Repository for working with user entity
    /// </summary>
    public interface IUserRepository : IRepositoryBase<User>
    {
        /// <summary>
        /// Method for get user by id from db
        /// </summary>
        /// <returns>returned user with data if exist or null</returns>
        Task<User?> GetUserById(Guid id, CancellationToken ct);

        ///// <summary>
        ///// Method for get user by email from db
        ///// </summary>
        ///// <returns>returned user with data if exist or null</returns>
        //Task<User?> GetUserByEmail(string email, CancellationToken ct);
    }
}
