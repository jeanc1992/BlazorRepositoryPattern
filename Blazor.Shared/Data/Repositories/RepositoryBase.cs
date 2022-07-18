using Blazor.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blazor.Shared.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity : class where TContext:DbContext 
    {
        private readonly IDbContextFactory<TContext> _factory;
        public RepositoryBase(IDbContextFactory<TContext> factory)
        {
            _factory = factory;
        }

        public  async Task<bool> Add(TEntity entity)
        {
            using (var context = _factory.CreateDbContext())
            {
                var query = context.Set<TEntity>();
                query.Add(entity);
                var result = await context.SaveChangesAsync();
                return result != 0;
            };
        }

        public async Task<bool> AddRange(IEnumerable<TEntity> entity)
        {
            using (var context = _factory.CreateDbContext()) {
                var query = context.Set<TEntity>();
                query.AddRange(entity);

                var result = await context.SaveChangesAsync();
                return result == 0;
            };
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
            string includeProperties = "")
        {
            var context = _factory.CreateDbContext();
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query,
                (current, includeProperty) => current.Include(includeProperty.Trim()));

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }


        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var context = _factory.CreateDbContext();
            var query = context.Set<TEntity>();
            return await query.FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            var context = _factory.CreateDbContext();
            var query = context.Set<TEntity>();
            return query.Where(expression);
        }

        public void Dispose()
        {
            _factory.CreateDbContext().Dispose();
        }
    }
}
