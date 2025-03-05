using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intro.NET.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Test()
        {
            var a = 10;
            dynamic b;
            b = 10;

            ViewBag.Name = "Rono";
            ViewBag.ID = 1;

            ViewData["Name1"] = "Abrar";
            ViewData["ID1"] = 2;

            return View();
        }

        public ActionResult Redirecting()
        {
            TempData["Msg"] = "Redirected from Redirecting";
            return RedirectToAction("Test");
        }

        public ActionResult Goto()
        {
            return Redirect("https://www.aiub.edu/");
        }

        public ActionResult newHome()
        {
            return View();
        }
    }
}