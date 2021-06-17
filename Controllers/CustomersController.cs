using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly_MVCProject.Models;
using Vidly_MVCProject.ViewModels;

namespace Vidly_MVCProject.Controllers
{
    [AllowAnonymous]
    public class CustomersController : Controller
    {
        private AppDbContext _appDbContext;

        public CustomersController()
        {
            _appDbContext = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _appDbContext.Dispose();
        }

        public ActionResult Index()
        {
            // var customers = _appDbContext.Customers.Include(c => c.MembershipType).ToList();
            //now we are returning data from api
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _appDbContext.Customers.Include(c => c.MembershipType).Single(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _appDbContext.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _appDbContext.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _appDbContext.Customers.Add(customer);
            else
            {
                var customerInDb = _appDbContext.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _appDbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _appDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _appDbContext.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}