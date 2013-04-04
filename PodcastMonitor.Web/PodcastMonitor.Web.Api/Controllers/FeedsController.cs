﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using PodcastMonitor.Services.Feed.Contracts;
using PodcastMonitor.Web.Api.Models.Feed;

namespace PodcastMonitor.Web.Api.Controllers
{
    public class FeedsController : ApiController
    {
        private readonly Lazy<IFeedService> _feedsService;
        private readonly IMappingEngine _mapper;

        public FeedsController(Lazy<IFeedService> feedsService, IMappingEngine mapper)
        {
            _feedsService = feedsService;
            _mapper = mapper;
        }

        // GET api/feeds
        public FeedViewModel Get()
        {
            var feeds = _feedsService.Value.GetFeeds();
            var feedsViewModel = _mapper.Map<FeedViewModel>(feeds.Feeds.First());
            return feedsViewModel;
        }

        // GET api/feeds/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/feeds
        public void Post([FromBody]string value)
        {
        }

        // PUT api/feeds/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/feeds/5
        public void Delete(int id)
        {
        }
    }
}