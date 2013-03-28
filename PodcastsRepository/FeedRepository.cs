using System;
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

        public IEnumerable<Feed> GetAll()
        {
            List<Feed> feeds;
            try
            {
                feeds = (from f in _feedStore.CreateQuery()
                       select f).ToList();
            
            }
            catch (Exception e)
            {

                feeds = new List<Feed>
                            {
                                new Feed{Id = 1, Uri = e.Message, Name=e.GetBaseException().StackTrace, Category = e.InnerException.ToString()},
                                new Feed{Id = 2, Uri = "myuri2", Name= "22222", Category = "stuff"}
                            }; ;
            }
            
            return feeds;
        }

        public Feed Get(int id)
        {
            var feeds = from f in _feedStore.CreateQuery()
                        where f.Id == id
                        select f;
            return feeds.FirstOrDefault();
        }

        public IEnumerable<Feed> GetByCategory(string category)
        {
            var feeds = from f in _feedStore.CreateQuery()
                        where f.Category == category
                        select f;
            return feeds;
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