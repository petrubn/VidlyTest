using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO.MemoryMappedFiles;
using Microsoft.Ajax.Utilities;
using VidlyTest.Models;
using VidlyTest.ViewModels;

namespace VidlyTest.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Context _context;

        public CustomersController()
        {
            _context = new Context();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();

            return View(customers);
        }

        // [Route("Customers/MyDetails/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();

            return View(customer);
        }
        public ActionResult Customers()
        {
            var customers = _context.Customers.ToList();
            // var customers = _context.Customers.SingleOr
            return View(customers);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes,
            };
            
            return View("CustomerForm", viewModel);
        }
        
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                    
                return View("CustomerForm", viewModel);
            }
            
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        #region test
        
        

        #endregion
    }
}