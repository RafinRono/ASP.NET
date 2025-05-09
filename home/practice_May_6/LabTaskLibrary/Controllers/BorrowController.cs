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
            var borrows = db.Borrows.ToList();
            foreach (var borrow in borrows)
            {
                var ExpireDate = borrow.Time.AddDays(7);
                if (System.DateTime.Now > ExpireDate)
                    borrow.Status = "Expired";
                db.SaveChanges();
            }

            var data = db.Books.ToList();
            return View(BookController.Convert(data));
        }
        public ActionResult Borrow(int id)
        {
            var user = (Login)Session["User"];
            var borrow = new Borrow()
            {
                Time = DateTime.Now,
                Qty = 1,
                CreatedBy = user.Id,
                Status = "Borrowing",
                SId = (int)Session["SId"]
            };

            db.Borrows.Add(borrow);
            db.SaveChanges();

            var borrowD = new BorrowDetail()
            {
                BrwId = borrow.Id,
                BkId = id,
                Qty = 1
            };

            db.BorrowDetails.Add(borrowD);

            if (db.SaveChanges() > 0)
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

        [HttpGet]
        public ActionResult SeeBorrows()
        {
            return View(db.Borrows.ToList());
        }

        [HttpGet]
        public ActionResult Return(int id) {
            var Borrow = db.Borrows.Find(id);
            Borrow.Status = "Returned";
            db.SaveChanges();
            return RedirectToAction("SeeBorrows");
        }
    }
}