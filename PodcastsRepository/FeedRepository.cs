using System.Collections.Generic;
using System.Linq;
using PodcastModel;
using Stores;

namespace PodcastsRepository
{
    public class FeedRepository : IRepository<Feed>
    {
        private readonly IStore<Feed> _feedStore;

        public FeedRepository(IStore<Feed> feedStore)
        {
            _feedStore = feedStore;
        }

        public IEnumerable<Feed> Get()
        {
            var feeds = from f in _feedStore.CreateQuery()
                       select f;

            return feeds;
        }

        public Feed Get(int id)
        {
            var feeds = from f in _feedStore.CreateQuery()
                        where f.Id == id
                        select f;
            return feeds.FirstOrDefault();
        }

        public void Put(Feed item)
        {
            _feedStore.Add(item);
        }

        public void Delete(int id)
        {
            _feedStore.Delete(new Feed{Id = id});
        }
    }
}