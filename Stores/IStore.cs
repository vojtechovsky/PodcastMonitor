using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stores
{
    public interface IStore<T> where T : class
    {
        T Find(params object[] keyValues);
        void Add(T item, bool useUnitOfWork = false);
        void Delete(T item, bool useUnitOfWork = false);
        void Update(T item, bool useUnitOfWork = false);
        void Update(T existingItem, T updatedItem, bool useUnitOfWork = false);
        IQueryable<T> CreateQuery();
        void Delete(Expression<Func<T, bool>> predicate);
    }
}
