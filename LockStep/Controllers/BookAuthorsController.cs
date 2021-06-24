using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LockStep.Library.Domain;
using LockStep.Library.Persistence;

namespace LockStep.Web.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly IBookAuthorRepository db;

        public BookAuthorsController(IBookAuthorRepository db)
        {
            this.db = db;
        }



        // GET: BookAuthors
        public async Task<ActionResult> Index()
        {
            return View(await db.Get());
        }

        // GET: BookAuthors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthor bookAuthor = await db.GetById(id);
            if (bookAuthor == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthor);
        }

        // GET: BookAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookAuthors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                await db.Insert(bookAuthor);
                
                return RedirectToAction("Index");
            }

            return View(bookAuthor);
        }

        // GET: BookAuthors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthor bookAuthor = await db.GetById(id);
            if (bookAuthor == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthor);
        }

        // POST: BookAuthors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                await db.Update(bookAuthor);
                return RedirectToAction("Index");
            }
            return View(bookAuthor);
        }

        // GET: BookAuthors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthor bookAuthor = await db.GetById(id);
            if (bookAuthor == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthor);
        }

        // POST: BookAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BookAuthor bookAuthor = await db.GetById(id);
            await db.Delete(bookAuthor);
            
            return RedirectToAction("Index");
        }

       
    }
}
