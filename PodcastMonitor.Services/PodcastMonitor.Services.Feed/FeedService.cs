using System;
using System.ServiceModel;
using System.ServiceProcess;
using AutoMapper;
using PodcastMonitor.DataRepository;
using PodcastMonitor.Services.Feed.Contracts;
using Unity.Wcf;

namespace PodcastMonitor.Services.Feed
{
    public class FeedService : ServiceBase, IFeedService
    {
        private readonly IDataRepository<DataModel.Model.Feed> _feedRepository;
        public ServiceHost ServiceHost = null;

        public FeedService(IDataRepository<DataModel.Model.Feed> feedRepository)
        {
            _feedRepository = feedRepository;
        }

        public GetFeedsResponse GetFeeds()
        {
            var feeds = _feedRepository.GetData("Id");

            var response = Mapper.Map<GetFeedsResponse>(feeds);

            return response;
        }

        protected override void OnStart(string[] args)
        {
            if (ServiceHost != null)
            {
                ServiceHost.Close();
            }
            var container = UnityResolver.GetContainer();

            // Create a ServiceHost for the Service type and provide the base address.
            ServiceHost = new UnityServiceHost(container,typeof(FeedService),new Uri[0]);
            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            ServiceHost.Open();
        }

        protected override void OnStop()
        {
            if (ServiceHost != null)
            {
                ServiceHost.Close();
                ServiceHost = null;
            }
        }

    }
}
