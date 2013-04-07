using System.ComponentModel.DataAnnotations;

namespace PodcastMonitor.DataModel.Model
{
    public class Feed
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Uri { get; set; }

        public Category Category { get; set; }

        public FeedSet FeedSet { get; set; }
    }

    public class FeedUser
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string UserName { get; set; }
    }

    public class FeedSet
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public FeedUser FeedUser { get; set; }
    }
}
