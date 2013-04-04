using System.Runtime.Serialization;

namespace PodcastMonitor.Services.Feed.Contracts
{
    [DataContract]
    public class Feed
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(Name = "FeedName")]
        public string Name { get; set; }

        [DataMember]
        public string Uri { get; set; }

        [DataMember]
        public Category Category { get; set; }
    }
}