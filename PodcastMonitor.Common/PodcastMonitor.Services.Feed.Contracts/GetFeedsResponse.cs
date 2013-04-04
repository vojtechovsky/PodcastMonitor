using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PodcastMonitor.Services.Feed.Contracts
{
    [DataContract]
    public class GetFeedsResponse
    {
        [DataMember]
        public IEnumerable<Feed> Feeds { get; set; }
    }
}