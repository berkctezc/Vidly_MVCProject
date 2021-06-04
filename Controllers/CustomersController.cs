using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.Controllers
{
    public class CustomersController : Controller
    {
        private Context _context;

        public CustomersController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).Single(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}