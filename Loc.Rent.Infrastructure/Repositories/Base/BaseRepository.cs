using Loc.Rent.ApplicationCore.Gateways.Base;
using Loc.Rent.Domain.Entities.Base;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Loc.Rent.Infrastructure.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {
        private ISession _session;
        public BaseRepository(ISession session) => _session = session;
        public async Task<bool> SaveOrUpdate<T>(T item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveOrUpdateAsync(item);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
                return false;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public Task<ICollection<T>> FindAllAsync<T>(params Expression<Func<T, bool>>[] where) where T : EntityBase
        {
            return Task.Run<ICollection<T>>(() => this.FindAll<T>(where).ToList());
        }

        public IQueryable<T> FindAll<T>(params Expression<Func<T, bool>>[] where)  where T : EntityBase
        {
            var query = _session.Query<T>();

            if (where != null && where.Any(c => c != null))
            {
                foreach (var q in where.Where(c => c != null))
                    query = query.Where(q);
            }

            return query;
        }

        public T FindById<T>(object id) where T : EntityBase
        {
            return _session.Get<T>(id);
        }

        public Task<T> FindByIdAsync<T>(object id) where T : EntityBase
        {
            return _session.GetAsync<T>(id);
        }

        public Task<T> FindAsync<T>(params Expression<Func<T, bool>>[] where) where T : EntityBase
        {
            return Task.Run<T>(() => this.FindAll<T>(where).FirstOrDefault());
        }

    }
}
