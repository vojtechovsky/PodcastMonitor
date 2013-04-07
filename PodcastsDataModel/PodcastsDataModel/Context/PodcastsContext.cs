using System.Data.Entity;
using PodcastMonitor.DataModel.Model;
using PodcastMonitor.Stores;

namespace PodcastMonitor.DataModel.Context
{
    public class PodcastsContext : DbContext, IUnitOfWork
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FeedSet> FeedSets { get; set; }
        public DbSet<FeedUser> FeedUsers { get; set; }

        public PodcastsContext()
        { }

        public PodcastsContext(string connectionString)
            : base(connectionString)
        {
            
        }
    }
}