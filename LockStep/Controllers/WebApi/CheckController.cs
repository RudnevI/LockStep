using LockStep.Library.Domain;
using LockStep.Library.Domain.Finance;
using LockStep.Library.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LockStep.Web.Controllers.WebApi
{
    
    public class CheckController : ApiController
    {
        private readonly LibraryDbContext _context = new LibraryDbContext();
        // GET: Default
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {

                if (!IsValidId(id)) return BadRequest();
                Book book = await GetBook(id);
                if (book == null) return NotFound();
                List<Price> prices =  _context.Prices.Where(p => p.Book.Id == id).ToList();
               
                if (prices == null || prices.Count == 0) return NotFound();
                Price price = prices.Where( p => p.To == prices.Select(s => s.From).ToList().Max()).FirstOrDefault();
                if (price == null) price = prices.Where(p => p.From == null).FirstOrDefault();
             
                return Ok(new {book.Name, price.Value});
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
            

        }

        private int? GetMaxId()
        {
            return _context.Books.Select(b => b.Id).Max();
        }

        private bool IsValidId(int id)
        {
            int? maxId = GetMaxId();
            //TODO: Рассмотреть вариант с maxId равным null
            return !(id <= 0 || id > maxId);
        }

        

        private async Task<Book>GetBook(int id)
        {
            try
            {
                return await _context.Books.FindAsync(id);
            }
            catch
            {
                return null;            
            }
        }
    }
}