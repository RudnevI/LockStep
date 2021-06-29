using LockStep.Library.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LockStep.Web.Controllers.WebApi
{
    public class AuthorsController : ApiController
    {
        private readonly LibraryDbContext _context = new LibraryDbContext();
        // GET: Authors
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_context.Authors.ToList());
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}