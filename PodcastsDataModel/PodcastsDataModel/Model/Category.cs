using System.ComponentModel.DataAnnotations;

namespace PodcastMonitor.DataModel.Model
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }
    }
}