using AutoMapper;
using Microsoft.Practices.Unity;
using PodcastMonitor.DataModel.Context;
using PodcastMonitor.DataRepository;
using PodcastMonitor.Services.Feed.Contracts;
using PodcastMonitor.Stores;
using System.Configuration;
using System.Data.Entity;
using Unity.Wcf;

namespace PodcastMonitor.Services.Feed
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Podcasts"].ConnectionString;

            container
                .RegisterInstance(Mapper.Engine)
                .RegisterType<PodcastsContext>(new HierarchicalLifetimeManager(),
                                               new InjectionConstructor(connectionString))
                .RegisterType<DbContext, PodcastsContext>()
                .RegisterType<IUnitOfWork, PodcastsContext>()
                .RegisterType(typeof (IStore<>), typeof (Store<>))
                .RegisterType<IDataRepository<DataModel.Model.Feed>, FeedRepository.FeedRepository>()
                .RegisterType<IFeedService, FeedService>();
        }
    }

}