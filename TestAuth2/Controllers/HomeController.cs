using System.Web.Mvc;
using System.Web.UI;

namespace TestAuth2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 0,/* Location = OutputCacheLocation.Server,*/ VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}