using LockStep.Library.Domain;
using LockStep.Library.Domain.Finance;
using LockStep.Library.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace LockStep.Web.Controllers.WebApi
{

    [Serializable]
    public class QueryResult
    {
        
        public string Name { get; set; }

        public string Value { get; set; }

        public QueryResult(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
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


                List<QueryResult> result = _context.Books.Join(
                   _context.Prices,
                   book => book.Id,
                   price => price.Book.Id,
                   (book, price) => new
                   QueryResult(book.Name, price.Value)
                   )
                    .ToList()
                    
                    
                    ;
/*
                IEnumerable<QueryResult>query = ((IEnumerable<QueryResult>)(from book in books
                             join price in prices
                             on book.Id equals price.Book.Id
                             where price.To == null
                             select new
                             {
                                 book?.Name,
                                 price?.Value
                             }));
*/
               /* Book book = books.Where(b => b.Id == id).FirstOrDefault();*/
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


    }
   

}
