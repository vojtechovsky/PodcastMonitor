using System.Collections.Generic;
using PodcastMonitor.DataRepository;
using PodcastMonitor.Web.Api.Models.Feed;

namespace PodcastMonitor.Web.Frontend.FeedRepository
{
    public class FeedRepository : IDataRepository<FeedViewModel>
    {
        public IEnumerable<FeedViewModel> GetData(string sortBy)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FeedViewModel> GetDataForUser(string sortBy, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
