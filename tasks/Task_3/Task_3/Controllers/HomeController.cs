using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_3.EF;

namespace Task_3.Controllers
{
    public class HomeController : Controller
    {
        ASP_NET_TEST_2Entities db = new ASP_NET_TEST_2Entities();

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

        public ActionResult CategoryIndex()
        {
            ViewBag.Message = "Your contact page.";
            var data =db.Categories.ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            ViewBag.Message = "Your contact page.";

            db.Categories.Add(c);
            if(db.SaveChanges() > 0) 
            {
                TempData["Msg"] = "Category Added";
                return RedirectToAction("CategoryIndex");
            }

            TempData["Msg"] = "Category not Added";
            return View();
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            var exobj = db.Categories.Find(c.Id);
            exobj.Name = c.Name;

            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Category Edited";
                return RedirectToAction("CategoryIndex");
            }

            TempData["Msg"] = "Category NOT Edited";
            return View();
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            var data = db.Categories.Find(id);
            //db.Students.Remove(data);
            return View(data);
        }

        [HttpPost]
        public ActionResult DeleteCategory(Category c)
        {
            var data = db.Categories.Find(c.Id);
            db.Categories.Remove(data);

            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Category Removed";
                return RedirectToAction("CategoryIndex");
            }

            TempData["Msg"] = "Category NOT Removed";
            return View();
        }

        public ActionResult ProductIndex()
        {
            ViewBag.Message = "Your contact page.";
            var data = db.Products.ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            ViewBag.Message = "Your contact page.";

            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            ViewBag.Message = "Your contact page.";

            db.Products.Add(p);
            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Product Added";
                return RedirectToAction("ProductIndex");
            }

            TempData["Msg"] = "Product not Added";
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            var exobj = db.Products.Find(p.Id);

            exobj.Name = p.Name;
            exobj.Price = p.Price;
            exobj.Qty = p.Qty;
            exobj.Cid = p.Cid;

            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Product Edited";
                return RedirectToAction("ProductIndex");
            }

            TempData["Msg"] = "Product NOT Edited";
            return View();
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            var data = db.Products.Find(id);
            //db.Students.Remove(data);
            return View(data);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product p)
        {
            var data = db.Products.Find(p.Id);
            db.Products.Remove(data);

            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Products Removed";
                return RedirectToAction("ProductIndex");
            }

            TempData["Msg"] = "Products NOT Removed";
            return View();
        }
    }
}