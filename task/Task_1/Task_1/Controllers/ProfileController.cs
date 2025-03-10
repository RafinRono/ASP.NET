using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Education()
        {
            var e1 = new Education()
            {
                Degree = "BSc CSE",
                Institute = "AIUB",
                Year = 2023,
                Result = 4.00
            };

            var e2 = new Education()
            {
                Degree = "MSc CSE",
                Institute = "NSU",
                Year = 2024,
                Result = 3.82
            };

            Education[] educations = new Education[] { e1, e2 };

            return View(educations);
        }

        public ActionResult Project()
        {
            var p1 = new Project()
            {
                Title = "OOP1",
                Course = "Object Oriented Programming 1 - Java",
                Description = "Intoductions to the basic of JFrame desktop application development"
            };

            var p2 = new Project()
            {
                Title = "OOP2",
                Course = "Object Oriented Programming 2 - C#",
                Description = "Intoductions to Windows Form desktop application development using .NET Framework"
            };

            var p3 = new Project()
            {
                Title = "Web Tech",
                Course = "Web Technologies",
                Description = "Intoductions to the basics of web development using html, php, javascript, AJAX"
            };

            Project[] projects = new Project[] { p1, p2, p3 };

            return View(projects);
        }

        public ActionResult Ref()
        {
            return View();
        }
    }
}