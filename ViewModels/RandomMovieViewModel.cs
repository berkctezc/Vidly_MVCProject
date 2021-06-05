using System.Collections.Generic;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}