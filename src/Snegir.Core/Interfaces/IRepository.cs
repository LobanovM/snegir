using System.Linq.Expressions;

namespace Snegir.Core.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> Get();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task Remove(TEntity item);
        Task Update(TEntity item);
    }
}
