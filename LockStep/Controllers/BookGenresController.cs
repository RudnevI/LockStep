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
    public class BookGenresController : Controller
    {
        private readonly IBookGenreRepository db;

        public BookGenresController(IBookGenreRepository db)
        {
            this.db = db;
        }



        // GET: BookGenres
        public async Task<ActionResult> Index()
        {
            return View(await db.Get());
        }

        // GET: BookGenres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenre bookGenre = await db.GetById(id);
            if (bookGenre == null)
            {
                return HttpNotFound();
            }
            return View(bookGenre);
        }

        // GET: BookGenres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookGenres/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] BookGenre bookGenre)
        {
            if (ModelState.IsValid)
            {
                await db.Insert(bookGenre);
                return RedirectToAction("Index");
            }

            return View(bookGenre);
        }

        // GET: BookGenres/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenre bookGenre = await db.GetById(id);
            if (bookGenre == null)
            {
                return HttpNotFound();
            }
            return View(bookGenre);
        }

        // POST: BookGenres/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] BookGenre bookGenre)
        {
            if (ModelState.IsValid)
            {
                await db.Update(bookGenre);
                return RedirectToAction("Index");
            }
            return View(bookGenre);
        }

        // GET: BookGenres/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenre bookGenre = await db.GetById(id);
            if (bookGenre == null)
            {
                return HttpNotFound();
            }
            return View(bookGenre);
        }

        // POST: BookGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BookGenre bookGenre = await db.GetById(id);
            await db.Delete(bookGenre);
            return RedirectToAction("Index");
        }

       
    }
}
