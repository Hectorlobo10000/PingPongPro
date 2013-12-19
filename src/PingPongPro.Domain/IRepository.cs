using System;
using System.Linq;
using System.Linq.Expressions;

namespace PingPongPro.Domain
{
    public interface IRepository
    {
        TEntity Create<TEntity>(TEntity tournament) where TEntity :class, IEntity;
        void Archive<T>(Guid id) where T : class, IEntity, IArchivable;
        T Update<T>(T item) where T : class, IEntity;
        T Get<T>(Guid id) where T : class, IEntity;
        T Get<T>(Expression<Func<T, bool>> queryExpression) where T : class, IEntity;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> queryExpression) where T : class, IEntity;
        IQueryable<T> QueryArchived<T>(Expression<Func<T, bool>> queryExpression) where T : class, IEntity, IArchivable;
    }
}