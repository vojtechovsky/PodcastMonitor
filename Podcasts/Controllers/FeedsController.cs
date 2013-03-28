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
    public class FeedsController : ApiController
    {
        private readonly IRepository<Feed> _feedRepository;

        public FeedsController(IRepository<Feed> feedRepository)
        {
            _feedRepository = feedRepository;
        }

        // GET api/values
        public IEnumerable<Feed> GetAll()
        {
            var feeds = _feedRepository.GetAll();
            return feeds;
        }

        // GET api/values/5
        public Feed Get(int id)
        {
            var feed = _feedRepository.Get(id);
            if (feed == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return feed;
        }

        public IEnumerable<Feed> GetFeedsByCategory(string category)
        {
            var feed = _feedRepository.GetByCategory(category);
            if (feed == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return feed.Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostProduct(Feed item)
        {
            _feedRepository.Put(item);
            var response = Request.CreateResponse<Feed>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
