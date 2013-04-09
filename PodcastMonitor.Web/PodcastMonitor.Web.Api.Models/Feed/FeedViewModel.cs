

using System.Collections.Generic;

namespace PodcastMonitor.Web.Api.Models.Feed
{
    public class FeedListViewModel
    {
        public List<FeedViewModel> Feeds { get; set; }
    }

    public class FeedViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Uri { get; set; }

        public CategoryViewModel Category { get; set; }

        public int FeedSetId { get; set; }

        public string FeedSetName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}