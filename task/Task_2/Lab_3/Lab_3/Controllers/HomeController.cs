using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_3.Models;


namespace Lab_3.Controllers
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

        [HttpGet]
        public ActionResult Info()
        {
            ViewBag.Message = "Your contact page.";

            return View(new Student());
        }

        [HttpPost]
        public ActionResult Info(Student s)
        {
            ViewBag.Message = "Your contact page.";

            return View(s);
        }
    }
}