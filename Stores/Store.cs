using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Stores
{
    public class Store<T> : IStore<T> where T : class
    {
        protected readonly DbContext _context;

        public Store(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public T Find(params object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public void Add(T item, bool useUnitOfWork)
        {
            _context.Entry(item).State = EntityState.Added;
            SaveChanges(useUnitOfWork);
        }

        public void Update(T item, bool useUnitOfWork)
        {
            _context.Entry(item).State = EntityState.Modified;
            SaveChanges(useUnitOfWork);
        }

        public void Update(T oldItem, T newItem, bool useUnitOfWork)
        {
            _context.Entry(oldItem).CurrentValues.SetValues(newItem);
            SaveChanges(useUnitOfWork);
        }

        public void Delete(T item, bool useUnitOfWork)
        {
            _context.Entry(item).State = EntityState.Deleted;
            SaveChanges(useUnitOfWork);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> records = from x in _context.Set<T>().Where<T>(predicate) select x;

            foreach (T record in records)
            {
                _context.Entry(record).State = EntityState.Deleted;
            }
        }

        public IQueryable<T> CreateQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        private void SaveChanges(bool useUnitOfWork)
        {
            if (useUnitOfWork == false)
            {
                _context.SaveChanges();
            }
        }
    }
}