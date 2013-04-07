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
            var user = new FeedUser{Id = 1, UserName = "MyName"};
            var feedSet = new FeedSet {FeedUser = user, Id = 1, Name = "FirstSet"};
            var cat = new Category {Id = 1, Name = "stuff"};
            context.FeedUsers.AddOrUpdate(u => u.Id, user);
            context.FeedSets.AddOrUpdate(f => f.Id, feedSet);
            context.Categories.AddOrUpdate(c => c.Id, cat);
            context.Feeds.AddOrUpdate(f => f.Id, new Feed { Id = 1, Category = cat, Name = "FeedName", Uri = "httpstuff", FeedSet = feedSet});
        }
    }
}
