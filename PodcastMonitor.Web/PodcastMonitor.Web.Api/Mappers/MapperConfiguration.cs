using PodcastMonitor.Web.Api.Mappers.Feeds;

namespace PodcastMonitor.Web.Api.Mappers
{
    public static class MapperConfiguration
    {
        public static void Initialise()
        {
            FeedMapping.Initialise();
        }
    }
}