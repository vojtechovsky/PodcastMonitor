using System.Collections.Generic;

namespace PodcastsRepository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        IEnumerable<T> GetByCategory(string category);

        void Put(T item);

        void Delete(int id);
    }
}
