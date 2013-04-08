using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FeedRepository.Projections;
using PodcastMonitor.DataModel.Model;
using PodcastMonitor.DataRepository;
using PodcastMonitor.Stores;

namespace FeedRepository
{
    public class FeedRepository : IDataRepository<FeedProjection>
    {
        private readonly IStore<Feed> _feedStore;

        public FeedRepository(IStore<Feed> feedStore)
        {
            _feedStore = feedStore;
        }

        public IEnumerable<FeedProjection> GetData(string sortBy)
        {
            var productsToReturn = _feedStore.CreateQuery().Include(x => x.Category).OrderBy(sortBy)
                .Select(x => new FeedProjection
                                 {
                                     FeedSetId = x.FeedSet.Id, 
                                     FeedSetName = x.FeedSet.Name, 
                                     UserId = x.FeedSet.FeedUser.Id,
                                     UserName = x.FeedSet.FeedUser.UserName,
                                     CategoryId = x.Category.Id,
                                     CategoryName = x.Category.Name, 
                                     Id = x.Id, 
                                     Name = x.Name, 
                                     Uri = x.Uri
                                 }).ToList();
            
            return productsToReturn;
        }

        public IEnumerable<FeedProjection> GetDataForUser(string sortBy, int userId)
        {
            var productsToReturn = _feedStore.CreateQuery().Include(x => x.Category).OrderBy(sortBy)
                .Select(x => new FeedProjection
                                 {
                                     FeedSetId = x.FeedSet.Id,
                                     FeedSetName = x.FeedSet.Name,
                                     UserId = x.FeedSet.FeedUser.Id,
                                     UserName = x.FeedSet.FeedUser.UserName,
                                     CategoryId = x.Category.Id,
                                     CategoryName = x.Category.Name,
                                     Id = x.Id,
                                     Name = x.Name,
                                     Uri = x.Uri
                                 }).ToList();
            
            return productsToReturn;
        }
    }
}
