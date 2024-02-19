using Entities.Interfaces;

namespace Entities.Pagination
{
    public class PaginationResult<TEntity> where TEntity : IEntity
    {
        public IEnumerable<TEntity> Result { get; set; }
        public int TotalPages { get; set; }
    }
}
