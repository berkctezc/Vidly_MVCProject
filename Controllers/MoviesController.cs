using System.Web.Mvc;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name="Shrek!" };

            return View(movie);
        }
    }
}