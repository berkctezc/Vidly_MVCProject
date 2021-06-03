using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().Single(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Name="Orson Welles", Id =1},
                new Customer{Name="Alfred Hitchcock", Id =2},
                new Customer{Name="Akira Kurosawa", Id =3},
                new Customer{Name="Martin Scorsese", Id =4},
                new Customer{Name="Stanley Kubrick", Id =5},
            };
        }
    }
}