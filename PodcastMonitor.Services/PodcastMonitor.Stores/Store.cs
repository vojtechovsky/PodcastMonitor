using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PodcastMonitor.Stores
{
    public class Store<T> : IStore<T> where T : class
    {
        protected readonly DbContext Context;

        public Store(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            Context = context;
        }

        public T Find(params object[] keyValues)
        {
            return Context.Set<T>().Find(keyValues);
        }

        public void Add(T item, bool useUnitOfWork)
        {
            Context.Entry(item).State = EntityState.Added;
            SaveChanges(useUnitOfWork);
        }

        public void Update(T item, bool useUnitOfWork)
        {
            Context.Entry(item).State = EntityState.Modified;
            SaveChanges(useUnitOfWork);
        }

        public void Update(T oldItem, T newItem, bool useUnitOfWork)
        {
            Context.Entry(oldItem).CurrentValues.SetValues(newItem);
            SaveChanges(useUnitOfWork);
        }

        public void Delete(T item, bool useUnitOfWork)
        {
            Context.Entry(item).State = EntityState.Deleted;
            SaveChanges(useUnitOfWork);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> records = from x in Context.Set<T>().Where<T>(predicate) select x;

            foreach (T record in records)
            {
                Context.Entry(record).State = EntityState.Deleted;
            }
        }

        public IQueryable<T> CreateQuery()
        {
            return Context.Set<T>().AsQueryable();
        }

        private void SaveChanges(bool useUnitOfWork)
        {
            if (useUnitOfWork == false)
            {
                Context.SaveChanges();
            }
        }
    }
}