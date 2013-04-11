using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PodcastMonitor.Web.UI.Common;

namespace PodcastMonitor.Web.Api.Models.Feed
{
    public class FeedListViewModel
    {
        
        public List<FeedViewModel> Feeds { get; set; }
    }

 
    public class FeedViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name="Field name")]
        public string Name { get; set; }

        [Display(Name = "Feed URL")]
        public string Uri { get; set; }

        
        public CategoryViewModel Category { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int FeedSetId { get; set; }

        [Display(Name = "Feed set name")]
        public string FeedSetName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}