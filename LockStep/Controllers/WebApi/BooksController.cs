using LockStep.Library.Domain;
using LockStep.Library.Domain.Finance;
using LockStep.Library.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace LockStep.Web.Controllers.WebApi
{
    public class BooksController : ApiController
    {
        // GET: Books
        private readonly LibraryDbContext _context = new LibraryDbContext();
        
        public IHttpActionResult Get()
        {
            try
            {
                List<Book> books = _context.Books.ToList();
                List<Price> prices = _context.Prices.ToList();
                
                var query = from book in books
                            join price in prices
                            on book.Id equals price.Book.Id
                            where price.To == null
                            select new
                            {
                                book?.Name,
                                price?.Value
                            };
                

                return Ok(query?.ToList());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


    }

}
