using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PodcastModel
{
    public class PodcastContext : DbContext
    {
        public DbSet<Feed> Feeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}