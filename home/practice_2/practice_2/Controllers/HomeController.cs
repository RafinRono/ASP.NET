using practice_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice_2.Controllers
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

        public ActionResult Contact(Student s)
        {
            ViewBag.Message = "Your contact page.";

            return View(s);
        }

        [HttpGet]
        public ActionResult Info()
        {
            ViewBag.Message = "Add Information.";

            return View(new Student());
        }

        [HttpPost]
        public ActionResult Info(Student s)
        {
            ViewBag.Message = "Add Information.";

            if(ModelState.IsValid)
                //return RedirectToAction("Contact", "Home", routeValues: s);
                return View(s);

            return View(s);
        }
    }
}