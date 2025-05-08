using LabTaskLibrary.DTOs;
using LabTaskLibrary.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTaskLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public static Book Convert(BookDTO p)
        {
            return new Book()
            {
                Id = p.Id,
                Name = p.Name,
                AuthorName = p.AuthorName,
                AvailableQty = p.AvailableQty,
                ReleaseDate = p.ReleaseDate
            };
        }
        public static BookDTO Convert(Book p)
        {
            return new BookDTO()
            {
                Id = p.Id,
                Name = p.Name,
                AuthorName = p.AuthorName,
                AvailableQty = p.AvailableQty,
                ReleaseDate = p.ReleaseDate
            };
        }
        public static List<BookDTO> Convert(List<Book> list)
        {
            var products = new List<BookDTO>();
            foreach (var product in list)
            {
                products.Add(Convert(product));
            }
            return products;
        }
    }
}