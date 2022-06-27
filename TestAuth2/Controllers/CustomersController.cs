using System.Linq;
using System.Web.Mvc;
using TestAuth2.Models;
using System.Data.Entity;
using System.Web.Http;
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
            if (User.IsInRole("CanManageMovies"))
            {
                return View("List");
            }

            return View("ReadOnlyList");
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
        
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
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
        
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
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

        [System.Web.Mvc.HttpPost]
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
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