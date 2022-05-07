using Loc.Rent.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Loc.Rent.ApplicationCore.Gateways.Base
{
    public interface IBaseRepository
    {
        Task<bool> SaveOrUpdate<T>(T item);
        Task<ICollection<T>> FindAllAsync<T>(params Expression<Func<T, bool>>[] where) where T : EntityBase;
        public T FindById<T>(object id) where T : EntityBase;
        Task<T> FindAsync<T>(params Expression<Func<T, bool>>[] where) where T : EntityBase;
        Task<T> FindByIdAsync<T>(object id) where T : EntityBase;
        IQueryable<T> FindAll<T>(params Expression<Func<T, bool>>[] where) where T : EntityBase;        
    }
}
