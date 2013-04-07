using System.Runtime.Serialization;

namespace PodcastMonitor.Services.Feed.Contracts
{
    [DataContract]
    public class Feed
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Uri { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int FeedSetId { get; set; }

        [DataMember]
        public string FeedSetName { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}