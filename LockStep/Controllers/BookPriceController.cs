using LockStep.Library.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LockStep.Web.Controllers
{
    public class BookPriceController : Controller
    {
        private readonly LibraryDbContext _context = new LibraryDbContext(); 
        // GET: BookPrice
        
        public ActionResult Index()
        {
            if(HttpContext.Request.HttpMethod.Equals("post"))
            {
                int priceId = int.Parse(HttpContext.Request.Params.Get("priceId")); 
                int bookId = int.Parse(HttpContext.Request.Params.Get("bookId"));
                var book = _context.Books.Find(bookId);
                var price = _context.Prices.Find(priceId);
                price.Book = book;
                _context.SaveChanges();

            }
            return View();
        }
    }
}