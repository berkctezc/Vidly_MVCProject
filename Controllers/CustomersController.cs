using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer{Name="Orson Welles", Id =1},
                new Customer{Name="Alfred Hitchcock", Id =2},
                new Customer{Name="Akira Kurosawa", Id =3},
                new Customer{Name="Martin Scorsese", Id =4},
                new Customer{Name="Stanley Kubrick", Id =5},
            };
            return View(customers);
        }
        
        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer{Name="Orson Welles", Id =1},
                new Customer{Name="Alfred Hitchcock", Id =2},
                new Customer{Name="Akira Kurosawa", Id =3},
                new Customer{Name="Martin Scorsese", Id =4},
                new Customer{Name="Stanley Kubrick", Id =5},

            };

            return View(customers.Single(x => x.Id == id));
        }
    }
}