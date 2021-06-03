using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}