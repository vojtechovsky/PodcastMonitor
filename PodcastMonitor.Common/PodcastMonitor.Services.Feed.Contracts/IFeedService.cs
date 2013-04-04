using System.ServiceModel;

namespace PodcastMonitor.Services.Feed.Contracts
{
    [ServiceContract]
    public interface IFeedService
    {
        [OperationContract]
        GetFeedsResponse GetFeeds();
    }
}
