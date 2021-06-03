using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web.Mvc;
using Vidly_MVCProject.Models;
using Vidly_MVCProject.ViewModel;

namespace Vidly_MVCProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
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
                Movie = movie, Customers = customers
            };

            //passing data do view
            ViewData["Movie"] = movie;
            ViewBag.Movie = movie;


            return View(viewModel);


            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page="1",sortBy="name"});
        }

        public ActionResult Edit(int? id)
        {
            // Random random = new Random();
            if (!id.HasValue) id = new Random().Next(100);
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
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