using System.Data.Entity;

namespace PodcastsDataModel.Model
{
    public class PodcastsContext : DbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Category> Categories { get; set; }

        public PodcastsContext()
        { }

        public PodcastsContext(string connectionString)
            : base(connectionString)
        {
            
        }
    }
}