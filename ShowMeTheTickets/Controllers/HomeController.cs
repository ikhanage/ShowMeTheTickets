using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowMeTheTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IViaGoGoHelper _viaGoGoHelper;
        public HomeController(IViaGoGoHelper viaGoGoHelper)
        {
            _viaGoGoHelper = viaGoGoHelper;
        }
        public ActionResult Index()
        {
            _viaGoGoHelper.GetSearchResults();
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