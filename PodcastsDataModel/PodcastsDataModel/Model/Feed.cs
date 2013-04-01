using System.ComponentModel.DataAnnotations;

namespace PodcastsDataModel.Model
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

    public class Category
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }
    }

    //public class Listener
    //{
    //    public int Id { get; set; }

    //}
}
