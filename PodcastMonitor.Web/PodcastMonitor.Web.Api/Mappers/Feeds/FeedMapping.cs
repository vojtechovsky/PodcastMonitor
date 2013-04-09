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
            Mapper.CreateMap<GetFeedsResponse, FeedListViewModel>();

            Mapper.CreateMap<Feed, FeedViewModel>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
                .ForMember(dest => dest.FeedSetId, o => o.MapFrom(src => src.FeedSetId))
                .ForMember(dest => dest.FeedSetName, o => o.MapFrom(src => src.FeedSetName))
                .ForMember(dest => dest.UserId, o => o.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Uri, o => o.MapFrom(src => src.Uri))
                .ForMember(dest => dest.Category, o => o.MapFrom(src => new CategoryViewModel{ Id = src.CategoryId, Name = src.CategoryName}));
        }
    }
}