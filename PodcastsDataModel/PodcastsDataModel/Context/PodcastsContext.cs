using System.Data.Entity;
using PodcastMonitor.DataModel.Model;

namespace PodcastMonitor.DataModel.Context
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