using System;
using System.ServiceProcess;
using Microsoft.Practices.Unity;
using PodcastMonitor.Services.Feed.Contracts;

namespace PodcastMonitor.Services.Feed.Application
{
    public class FeedWindowsService 
    {
        public static void Main()
        {
            var container = UnityResolver.GetContainer();

            var service = container.Resolve<IFeedService>();

            if (Environment.UserInteractive)
            {
                service.GetFeeds();
            }
            else
            {
                var servicesToRun = new[] { service as ServiceBase };

                ServiceBase.Run(servicesToRun);
            }
        }
    }


}