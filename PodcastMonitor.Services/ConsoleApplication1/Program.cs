using System;
using System.Linq;
using System.ServiceModel;
using PodcastMonitor.Services.Feed.Contracts;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stillGoing = true;

            while (stillGoing)
            {
                Console.WriteLine("Enter the action you require:");
                var inChar = Console.ReadKey();
                switch (inChar.Key)
                {
                    case ConsoleKey.Q:
                        stillGoing = false;
                        break;
                    default:
                        var binding = new BasicHttpBinding();
                        var address = new EndpointAddress("http://localhost:8733/PodcastMonitor/FeedService");
                        var factory = new ChannelFactory<IFeedService>(binding, address);

                        IFeedService foo = factory.CreateChannel();
                        var result = foo.GetFeeds();
                        var x = new System.Xml.Serialization.XmlSerializer(result.Feeds.GetType());
                        x.Serialize(Console.Out, result.Feeds);
                        Console.WriteLine();
                        break;
                }    
            }
            
        }
    }
}
