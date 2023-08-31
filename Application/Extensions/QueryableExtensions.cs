using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Application.Configurations;


namespace Application.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, params Expression<Func<T, object>>[] includeProperties) where T : class, IEntity, new()
        {
            foreach (var includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);
            return queryable;
        }
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, params string[] includeProperties) where T : class, IEntity, new()
        {
            foreach (var includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);
            return queryable;
        }

        public static IQueryable<TEntity> ApplyQueryFilter<TEntity>(this IQueryable<TEntity> query, bool isFilterApplied = true) where TEntity : class, IEntity, new()
        {

            if (!isFilterApplied)
                return query.IgnoreQueryFilters();

            return query;
        }
        public static IQueryable<TEntity> ApplyAsNoTracking<TEntity>(this IQueryable<TEntity> query, bool isApplied = true) where TEntity : class, IEntity, new()
        {

            if (isApplied)
                return query.AsNoTracking();

            return query;
        }

    }
}
