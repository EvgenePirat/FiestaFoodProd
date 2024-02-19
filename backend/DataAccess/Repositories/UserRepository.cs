using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Implementation user repository interface for work with user 
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(StContext context) : base(context)
        {
        }

        //public async Task<User?> GetUserByLogin(string email, CancellationToken ct)
        //{
        //    return await _context.Users.Include(user => user.UserInformation).AsNoTracking().FirstOrDefaultAsync(temp => temp.Email == email, cancellationToken: ct);
        //}

        public async Task<User?> GetUserById(Guid id, CancellationToken ct)
        {
            return await _context.Users.Include(user => user.CustomerInfos).AsNoTracking().FirstOrDefaultAsync(temp => temp.Id == id, cancellationToken: ct);
        }
    }
}
