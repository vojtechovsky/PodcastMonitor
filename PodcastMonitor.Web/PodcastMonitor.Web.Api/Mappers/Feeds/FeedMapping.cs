using AutoMapper;
using PodcastMonitor.Services.Feed.Contracts;
using PodcastMonitor.Web.Api.Models.Feed;
using System.Collections.Generic;

namespace PodcastMonitor.Web.Api.Mappers.Feeds
{
    public static class FeedMapping
    {
        public static void Initialise()
        {
            Mapper.CreateMap<Feed, FeedViewModel>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
                .ForMember(dest => dest.Uri, o => o.MapFrom(src => src.Uri))
                ;

            Mapper.CreateMap<Category, CategoryViewModel>();
        }
    }
}