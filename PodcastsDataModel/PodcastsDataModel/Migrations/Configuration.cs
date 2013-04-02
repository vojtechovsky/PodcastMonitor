using PodcastMonitor.DataModel.Context;
using PodcastMonitor.DataModel.Model;
using System.Data.Entity.Migrations;

namespace PodcastMonitor.DataModel.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PodcastsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PodcastsContext context)
        {
            var cat = new Category {Id = 1, Name = "stuff"};
            context.Categories.AddOrUpdate(c => c.Id, cat);
            context.Feeds.AddOrUpdate(f => f.Id, new Feed { Id = 1, Category = cat, Name = "FeedName", Uri = "httpstuff" });
        }
    }
}
