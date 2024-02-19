using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CustomerInfoRepository : RepositoryBase<CustomerInfo>, ICustomerInfoRepository
    {
        public CustomerInfoRepository(StContext context) : base(context)
        {
        }

        public async Task<CustomerInfo?> GetCustomerInfoById(Guid id, CancellationToken ct)
        {
            return await _context.CustomerInfos.AsNoTracking().FirstOrDefaultAsync(temp => temp.Id == id, cancellationToken: ct);
        }
    }
}
