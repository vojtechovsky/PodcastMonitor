using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PodcastModel;
using PodcastsRepository;

namespace Web.Podcasts.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IRepository<Feed> FeedRepository;

        public ValuesController()
        {
            
        }

        public ValuesController(IRepository<Feed> feedRepository)
        {
            FeedRepository = feedRepository;
        }

        // GET api/values
        public IEnumerable<Feed> Get()
        {
            var feeds = FeedRepository.Get();
            return feeds;
        }

        // GET api/values/5
        public string Get(int id)
        {
            var feed = FeedRepository.Get(id);
            return feed.Name;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(Feed feed)
        {
            //FeedRepository
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            FeedRepository.Delete(id);
        }
    }
}