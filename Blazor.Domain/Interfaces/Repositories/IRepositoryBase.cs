using System.Linq.Expressions;

namespace Blazor.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable
    {
        Task<bool> Add(TEntity entity);

        Task<bool> AddRange(IEnumerable<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    }
}
