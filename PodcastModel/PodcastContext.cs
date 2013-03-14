
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Stores;

namespace PodcastModel
{
    public class PodcastContext : DbContext, IUnitOfWork
    {
        public DbSet<Feed> Feeds { get; set; }

        public PodcastContext()
        {
            
        }

        public PodcastContext(string connectionString)
            : base(connectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}