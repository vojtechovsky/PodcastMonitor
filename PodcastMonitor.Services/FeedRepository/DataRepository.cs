using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PodcastMonitor.DataModel.Model;
using PodcastMonitor.DataRepository;
using PodcastMonitor.Stores;

namespace FeedRepository
{
    public class DataRepository : IDataRepository<Feed>
    {
        private readonly IStore<Feed> _feedStore;

        public DataRepository(IStore<Feed> feedStore)
        {
            _feedStore = feedStore;
        }

        public IEnumerable<Feed> GetData(string sortBy)
        {

            var feeds = _feedStore.CreateQuery().OrderBy(sortBy).ToList();
            var productsToReturn = Mapper.Map<IEnumerable<Feed>>(feeds);
            return productsToReturn;
        }


    }
}
