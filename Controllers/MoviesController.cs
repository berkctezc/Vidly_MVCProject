using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly_MVCProject.Models;
using Vidly_MVCProject.ViewModels;

namespace Vidly_MVCProject.Controllers
{
    [AllowAnonymous]
    public class MoviesController : Controller
    {
        private AppDbContext _appDbContext;

        public MoviesController()
        {
            _appDbContext = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _appDbContext.Dispose();
        }

        public ActionResult Random()
        {
            //adding data
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "cust1"},
                new Customer {Name = "cust2"}
            };

            //filling viewmodel with data
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            //passing data do view
            ViewData["Movie"] = movie;
            ViewBag.Movie = movie;

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            var movie = _appDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _appDbContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _appDbContext.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _appDbContext.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _appDbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _appDbContext.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _appDbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult Index(int? pageIndex, string sortBy)
        {
            //if (User.IsInRole(RoleName.CanManageMovies))
            return View("List");

            //return View("ReadOnlyList");

            //var movies = _appDbContext.Movies.Include(m => m.Genre).ToList();
        }

        public ActionResult Details(int id)
        {
            var movie = _appDbContext.Movies.Include(m => m.Genre).Single(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Parameters(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(string.Format("PageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4}:range(1800,2021))}/{month:regex(\\d{2}:range(1,12))}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}