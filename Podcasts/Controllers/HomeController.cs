using System.Web.Mvc;

namespace Web.Podcasts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("../Feed/ListFeeds");
        }

        
    }
}
