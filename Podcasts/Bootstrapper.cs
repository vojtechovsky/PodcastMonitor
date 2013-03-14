using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Practices.Unity;
using PodcastModel;
using PodcastsRepository;
using Stores;

namespace Web.Podcasts
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PodcastContext"].ConnectionString;

            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();            
            container
                .RegisterType<IRepository<Feed>, FeedRepository>()
                .RegisterType(typeof (IStore<>), typeof (Store<>))
                
                .RegisterType<DbContext, PodcastContext>()
                .RegisterType<IUnitOfWork, PodcastContext>()
                .RegisterType<PodcastContext>(new HierarchicalLifetimeManager(), new InjectionConstructor(connectionString))
                ;
            return container;
        }
    }
}