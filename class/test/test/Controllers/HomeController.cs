﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //action methods
        {
            return View(); // View() is a function of type ActionResult
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(); // this function belongs to Controller Base class
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            ViewBag.Message = "Your Test page.";

            return View();
        }

    }
}