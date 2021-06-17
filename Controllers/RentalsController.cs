using System.Web.Mvc;

namespace Vidly_MVCProject.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }
    }
}