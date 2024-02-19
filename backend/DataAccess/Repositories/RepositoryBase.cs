using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Interfaces;
using Entities.Pagination;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly StContext _context;
        public RepositoryBase(StContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var dbTable = _context.Set<TEntity>();
            dbTable.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Set<TEntity>()
                .IncludeAll()
                .AsNoTracking()
                .ToListAsync(cancellationToken: ct);
        }

        public async Task<PaginationResult<TEntity>> GetPagedAsync(PaginationDb pagination, CancellationToken ct)
        {
            var dbTable = _context.Set<TEntity>().IncludeAll();
            var query = dbTable.AsQueryable();
            var result = await query
                .Select(x => new { Data = x, Count = query.Count() })
                .ToPagedListAsync(pagination)
                .AsNoTracking()
                .ToListAsync(cancellationToken: ct);
            var data = result.Select(x => x.Data).ToList();
            var count = result.Count;
            return new PaginationResult<TEntity>
            {
                Result = data,
                TotalPages = (int)Math.Ceiling((double)count / pagination.PageSize)
            };
        }

        public async Task<PaginationResult<TEntity>> GetPagedByQueryAsync(FilterState filter, CancellationToken ct)
        {
            var dbTable = _context.Set<TEntity>().IncludeAll();
            var query = dbTable.OrderByState(filter)
                .FilterByState(filter)
                .ToPagedListAsync(filter)
                .AsNoTracking();
            double count = await dbTable.CountAsync(cancellationToken: ct);
            return new PaginationResult<TEntity>
            {
                Result = await query.ToListAsync(ct),
                TotalPages = (int)Math.Ceiling(count / (int)filter.PageSize)
            };
        }

        public void Update(TEntity entity)
        {
            var dbTable = _context.Set<TEntity>();
            dbTable.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            var dbTable = _context.Set<TEntity>();
            dbTable.Remove(entity);
        }
    }
}
