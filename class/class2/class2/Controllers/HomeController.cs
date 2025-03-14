using class2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace class2.Controllers
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

        //public ActionResult Info(FormCollection fc) // using FormCollection
        //{
        //    ViewBag.Name = Request["Name"];
        //    ViewBag.Id = fc["Id"];
        //    return View();
        //}

        [HttpGet]
        public ActionResult Info() 
        {
            return View(new Student());
        }

        [HttpPost]
        //public ActionResult Info(string Name, string Id) //using variable mapping (name and type must be same on view and controller)
        //{
        //    ViewBag.Name = Request["Name"];
        //    ViewBag.Id = Id;
        //    return View();
        //}
        public ActionResult Info(FormCollection fc, string Email, Student s)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Contact", "Home", s);
            }

            ViewBag.Id = fc["Id"];
            ViewBag.Email = Email;
            return View(s);
        }
    }
}