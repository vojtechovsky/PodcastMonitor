using System.ComponentModel.DataAnnotations;

namespace PodcastModel
{
    public class Feed
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Uri { get; set; }

        [StringLength(300)]
        public string Category { get; set; }

    }
}
