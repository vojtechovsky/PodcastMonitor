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
    }
}
