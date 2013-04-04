

namespace PodcastMonitor.Web.Api.Models.Feed
{
    public class FeedViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Uri { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}