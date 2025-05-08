using LabTaskLibrary.DTOs;
using LabTaskLibrary.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTaskLibrary.Controllers
{
    public class BorrowController : Controller
    {
        private Library_MGTEntities db = new Library_MGTEntities();
        // GET: Order
        public ActionResult Index()
        {
            var data = db.Books.ToList();
            return View(BookController.Convert(data));
        }
        public ActionResult Borrow(int id)
        {
            var borrow = new Borrow()
            {
                Id = id,
                Time = DateTime.Now,
                Qty = 1,
                CreatedBy = 1,
                Status = "Borrowing"
            };

            db.Borrows.Add(borrow);

            if(db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Book Borrowed";
                TempData["class"] = "success";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "An Error occured";
            TempData["class"] = "danger";
            return View();
        }
        public ActionResult Cart()
        {
            if (Session["Cart"] != null)
            {
                var data = (List<BookDTO>)Session["Cart"];
                return View(data);
            }
            TempData["Msg"] = "Cart is empty";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Start()
        {
            return View(db.Students.ToList());
        }

        [HttpPost]
        public ActionResult Start(string Sid)
        {
            Session["SId"] = int.Parse(Sid);
            return RedirectToAction("Index");
        }
    }
}