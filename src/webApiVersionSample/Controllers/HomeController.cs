using System.Web.Mvc;

namespace webApiVersionSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}