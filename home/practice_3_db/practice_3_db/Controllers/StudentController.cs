using practice_3_db.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice_3_db.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        ASP_NET_TEST_1Entities db = new ASP_NET_TEST_1Entities();

        public ActionResult Index()
        {
            //ASP_NET_TEST_1Entities db = new ASP_NET_TEST_1Entities();
            var data = db.Students.ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            //validation
            //ASP_NET_TEST_1Entities db = new ASP_NET_TEST_1Entities();

            db.Students.Add(s);
            //db.SaveChanges();
            if(db.SaveChanges() > 0)
            {
                TempData["Msg"] = "User Added";
                return RedirectToAction("Index");
            }

            TempData["Msg"] = "User not Added";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Students.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var exobj = db.Students.Find(s.Id);
            //db.Entry(exobj).CurrentValues.SetValues(s);
            exobj.Name = s.Name;
            exobj.DOB = s.DOB;

            db.SaveChanges();
            TempData["Msg"] = "Student Updated";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Students.Find(id);
            //db.Students.Remove(data);
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            var data = db.Students.Find(s.Id);
            db.Students.Remove(data);

            db.SaveChanges();
            TempData["Msg"] = "Student Removed";

            return RedirectToAction("Index");
        }
    }
}