using System.Collections.Generic;

namespace PodcastsRepository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T Get(int id);

        void Put(T item);

        void Delete(int id);
    }
}
