using System.Configuration;
using System.Data.Entity;
using AutoMapper;
using Microsoft.Practices.Unity;
using PodcastMonitor.DataModel.Context;
using PodcastMonitor.DataRepository;
using PodcastMonitor.Services.Feed.Contracts;
using PodcastMonitor.Services.Feed.Mapping;
using PodcastMonitor.Stores;

namespace PodcastMonitor.Services.Feed
{
    public static class UnityResolver
    {
        public static IUnityContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Podcasts"].ConnectionString;
            MapperConfiguration.Initialise();
            var container = new UnityContainer();

            container
                .RegisterInstance(Mapper.Engine)
                .RegisterType<PodcastsContext>(new HierarchicalLifetimeManager(),
                                               new InjectionConstructor(connectionString))
                .RegisterType<DbContext, PodcastsContext>()
                .RegisterType<IUnitOfWork, PodcastsContext>()
                .RegisterType(typeof(IStore<>), typeof(Store<>))
                .RegisterType<IDataRepository<DataModel.Model.Feed>, FeedRepository.FeedRepository>()
                .RegisterType<IFeedService, FeedService>();

            return container;
        }
    }
}