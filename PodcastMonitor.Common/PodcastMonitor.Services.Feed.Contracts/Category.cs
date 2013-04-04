using System.Runtime.Serialization;

namespace PodcastMonitor.Services.Feed.Contracts
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(Name = "CategoryName")]
        public string Name { get; set; }
    }
}