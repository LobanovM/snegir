﻿using System.Linq.Expressions;

namespace Snegir.Core.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
