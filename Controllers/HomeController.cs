using System.Web.Mvc;
using System.Web.UI;

namespace Vidly_MVCProject.Controllers
{
    public class HomeController : Controller
    {
        //disable caching
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        //enable caching
        [OutputCache(Duration = 50,  //duration to keep cache
            Location = OutputCacheLocation.Server, //caching on server not client
            VaryByParam = "genre")] //cache for every genre
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}