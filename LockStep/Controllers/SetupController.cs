using LockStep.Library.Domain;
using LockStep.Library.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LockStep.Web.Controllers
{
    public class SetupController : Controller
    {
        private readonly LibraryDbContext _context;
        public SetupController()
        {
            _context = new LibraryDbContext();
        }
        // GET: Setup
        public ActionResult Index()
        {
            ViewBag.IsEmptyAuthors = !_context.Authors.Any();
            ViewBag.IsEmptyGenres = !_context.Genres.Any();
            ViewBag.IsEmptyBooks = !_context.Books.Any();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string create_authors, string create_genres, string create_books)
        {
            if (!string.IsNullOrWhiteSpace(create_authors))
            {
                _context.Authors.Add(new Author { Name = "Тестовый автор 1" });
                _context.Authors.Add(new Author { Name = "Тестовый автор 2" });
                _context.Authors.Add(new Author { Name = "Тестовый автор 3" });
            }
            if (!string.IsNullOrWhiteSpace(create_genres))
            {
                _context.Genres.Add(new Genre { Name = "Тестовый жанр 1" });
                _context.Genres.Add(new Genre { Name = "Тестовый жанр 2" });
                _context.Genres.Add(new Genre { Name = "Тестовый жанр 3" });
            }
            if (!string.IsNullOrWhiteSpace(create_books))
            {
                _context.Books.Add(new Book { Name = "Тестовая книга 1" });
                _context.Books.Add(new Book { Name = "Тестовая книга 2" });
                _context.Books.Add(new Book { Name = "Тестовая книга 3" });
            }
            try
            {
                _context.SaveChanges();
            }
            catch(Exception exception)
            {
                //extract exception stack
                ViewBag.Error = exception.Message;
                //log? maybe
            }
            ViewBag.IsEmptyAuthors = !_context.Authors.Any();
            ViewBag.IsEmptyGenres = !_context.Genres.Any();
            ViewBag.IsEmptyBooks = !_context.Books.Any();
            return View();
        }
    }
}