using System.Collections.Generic;
using AutoMapper;
using FeedRepository.Projections;
using PodcastMonitor.Services.Feed.Contracts;

namespace PodcastMonitor.Services.Feed.Mapping
{
    public static class MapperConfiguration
    {
        public static void Initialise()
        {
            FeedMapping.Initialise();
        }
    }

    public static class FeedMapping
    {
        public static void Initialise()
        {
            Mapper.CreateMap<IEnumerable<FeedProjection>, GetFeedsResponse>()
                .ForMember(dest => dest.Feeds, o => o.MapFrom(src => src));

            Mapper.CreateMap<FeedProjection, Contracts.Feed>();
        }
    }
}
