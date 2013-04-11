using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Web.Mvc;
using PodcastMonitor.Web.UI.Common;

namespace PodcastMonitor.Web.Api.Models.Feed
{
    public class CategoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Category name")]
        public string Name { get; set; }
    }
}