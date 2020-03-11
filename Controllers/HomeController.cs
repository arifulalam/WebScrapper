using System.Web.Mvc;
using WebScrapper.Switchs;

namespace WebScrapper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!new Switch()._switch()) return View("sitedown");

            return View();
        }

        public ActionResult About()
        {
            if (!new Switch()._switch()) return View("sitedown");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (!new Switch()._switch()) return View("sitedown");

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}