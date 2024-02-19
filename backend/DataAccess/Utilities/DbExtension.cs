using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Utilities
{
    public static class DbExtension
    {
        //public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable) where T : class
        //{
        //    var type = typeof(T);
        //    var properties = type.GetProperties();
        //    foreach (var property in properties)
        //    {
        //        var isVirtual = property.GetGetMethod()!.IsVirtual;
        //        if (isVirtual && properties.FirstOrDefault(c => c.Name == property.Name + "Id") != null)
        //        {
        //            queryable = queryable.Include(property.Name);
        //        }
        //    }
        //    return queryable;
        //}

        public static IQueryable<T> Include<T>(this IQueryable<T> source, IEnumerable<string> navigationPropertyPaths) where T : class
        {
            return navigationPropertyPaths.Aggregate(source, (query, path) => query.Include(path));
        }

        public static IQueryable<TEntity> IncludeAll<TEntity>(
            this DbSet<TEntity> dbSet,
            int maxDepth = int.MaxValue) where TEntity : class
        {
            IQueryable<TEntity> result = dbSet;
            var context = dbSet.GetService<ICurrentDbContext>().Context;
            var includePaths = GetIncludePaths<TEntity>(context, maxDepth);

            foreach (var includePath in includePaths)
            {
                result = result.Include(includePath);
            }

            return result;
        }

        public static IEnumerable<string> GetIncludePaths<T>(this DbContext context, int maxDepth = int.MaxValue)
        {
            if (maxDepth < 0)
                throw new ArgumentOutOfRangeException(nameof(maxDepth));

            var entityType = context.Model.FindEntityType(typeof(T));
            if (entityType == null)
            {
                throw new ArgumentException($"Unable to find the type: {typeof(T)} in the DbCOntext");
            }

            var includedNavigations = new HashSet<INavigation>();
            var stack = new Stack<IEnumerator<INavigation>>();

            while (true)
            {
                var entityNavigations = new List<INavigation>();
                if (stack.Count <= maxDepth)
                {
                    foreach (INavigation navigation in entityType.GetNavigations())
                    {
                        if (includedNavigations.Add(navigation))
                            entityNavigations.Add(navigation);
                    }

                    foreach (var entityTypeDerived in entityType.GetDerivedTypes())
                    {
                        foreach (INavigation navigation in entityTypeDerived.GetNavigations())
                        {
                            if (includedNavigations.Add(navigation))
                                entityNavigations.Add(navigation);
                        }
                    }
                }
                if (entityNavigations.Count == 0)
                {
                    if (stack.Count > 0)
                        yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
                }
                else
                {
                    foreach (var navigation in entityNavigations)
                    {
                        var inverseNavigation = navigation.Inverse;
                        if (inverseNavigation != null)
                            includedNavigations.Add(inverseNavigation);
                    }
                    stack.Push(entityNavigations.GetEnumerator());
                }
                while (stack.Count > 0 && !stack.Peek().MoveNext())
                    stack.Pop();
                if (stack.Count == 0) break;
                entityType = stack.Peek().Current.TargetEntityType;
            }
        }
        
    }
}
