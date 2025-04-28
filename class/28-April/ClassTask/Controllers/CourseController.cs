using ClassTask.DTO;
using ClassTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassTask.Controllers
{
    public class CourseController : Controller
    {
        private Sec_A_TestEntities1 db = new Sec_A_TestEntities1();
        // GET: Course
        public ActionResult Index()
        {
            var list = db.Courses.ToList();

            return View(Convert(list));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseDTO c)
        {
            if (ModelState.IsValid)
            {
                var cs = Convert(c);
                db.Courses.Add(cs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c);

        }

        public static Cours Convert(CourseDTO s)
        {
            return new Cours()
            {
                Name = s.Name,
                Capacity = s.Capacity,
            };
        }
        public static CourseDTO Convert(Cours s)
        {
            return new CourseDTO()
            {
                Name = s.Name,
                Capacity = s.Capacity,
            };
        }
        public static List<CourseDTO> Convert(List<Cours> list)
        {
            var data = new List<CourseDTO>();
            foreach (var c in list)
            {
                data.Add(Convert(c));
            }
            return data;
        }
    }
}