using System;
using System.Web.Http;
using AutoMapper;
using DevTrends.DynamicWcfProxy;
using Microsoft.Practices.Unity;
using PodcastMonitor.Services.Feed.Contracts;
using PodcastMonitor.Web.Api.Models.Feed;

namespace PodcastMonitor.Web.Api
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
            
            var container = new UnityContainer();

            container
                .RegisterInstance(Mapper.Engine)
                .RegisterType<Lazy<IFeedService>>(
                    new InjectionFactory(c => new Lazy<IFeedService>(DynamicWcfProxy<IFeedService>.Generate)))
                    ;

            return container;             
        }
    }
}