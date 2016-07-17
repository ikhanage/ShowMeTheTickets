using System.Web.Mvc;

namespace ShowMeTheTickets.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}