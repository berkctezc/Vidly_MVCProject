using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_MVCProject.Dtos;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private AppDbContext _appDbContext;

        public NewRentalsController()
        {
            _appDbContext =new AppDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _appDbContext.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _appDbContext.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _appDbContext.Rentals.Add(rental);
            }

            _appDbContext.SaveChanges();

            return Ok();
        }
    }
}
