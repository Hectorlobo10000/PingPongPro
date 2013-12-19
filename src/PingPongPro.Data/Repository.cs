using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using PingPongPro.Domain;

namespace PingPongPro.Data
{
    public class Repository : IRepository
    {
        readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        #region IWriteableRepository Members

        public T Create<T>(T item) where T : class, IEntity
        {
            _session.Save(item);
            return item;
        }

        public void Archive<T>(Guid id) where T : class, IEntity, IArchivable
        {
            var thingToDelete = _session.Get<T>(id);
            thingToDelete.Archive();
            _session.Update(thingToDelete);
        }

        public T Update<T>(T item) where T : class, IEntity
        {
            _session.Update(item);
            return item;
        }

        #endregion

        public T Get<T>(Guid id) where T : class, IEntity
        {
            return _session.Get<T>(id);
        }

        public T Get<T>(Expression<Func<T, bool>> queryExpression) where T : class, IEntity
        {
            return _session.Query<T>().Where(queryExpression).First();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> queryExpression) where T : class, IEntity
        {
            var query = _session.Query<T>().Where(queryExpression);
            if (typeof(IArchivable).IsAssignableFrom(typeof(T)))
            {
                query = query.Where(x => ((IArchivable)x).Archived == false);
            }

            return query;
        }

        public IQueryable<T> QueryArchived<T>(Expression<Func<T, bool>> queryExpression) where T : class, IEntity, IArchivable
        {
            return _session.Query<T>().Where(x => x.Archived).Where(queryExpression);
        }
    }
}