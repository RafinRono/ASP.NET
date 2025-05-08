using LabTaskLibrary.DTOs;
using LabTaskLibrary.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTaskLibrary.Controllers
{
    public class UserController : Controller
    {
        private Library_MGTEntities db = new Library_MGTEntities();
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(StudentDTO s)
        {
            //if (ModelState.IsValid)
            //{
            var data = Convert(s);
            db.Students.Add(data);
            db.SaveChanges();
            var login = new Login()
            {
                Username = data.Email,
                Password = data.Password,
                UserId = data.Id,
                Type = "Student"

            };
            db.Logins.Add(login);
            db.SaveChanges();
            TempData["Msg"] = "Registration Successfull";
            TempData["Class"] = "success";
            return RedirectToAction("Login");
            // }
            //return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UName, string Pass)
        {
            var user = (from u in db.Logins
                        where u.Username.Equals(UName) &&
                        u.Password.Equals(Pass)
                        select u).SingleOrDefault();
            if (user != null)
            {
                Session["User"] = user;
                if (user.Type.Equals("Student"))
                {
                    return RedirectToAction("Index", "Order");
                }
            }
            TempData["Msg"] = "Username or password invalid";
            TempData["Class"] = "danger";
            return View();
        }


        public static StudentDTO Convert(Student c)
        {
            return new StudentDTO()
            {
                Name = c.Name,
                Id = c.Id,
                Password = c.Password,
                Email = c.Email,

            };

        }
        public static Student Convert(StudentDTO c)
        {
            return new Student()
            {
                Name = c.Name,
                Id = c.Id,
                Password = c.Password,
                Email = c.Email,

            };
        }
        public static List<StudentDTO> Convert(List<Student> list)
        {
            var data = new List<StudentDTO>();
            foreach (var item in list)
            {
                data.Add(Convert(item));
            }
            return data;
        }
    }
}