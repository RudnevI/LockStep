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
    public class BookCommentsController : Controller
    {
        private readonly IBookCommentRepository db;

        public BookCommentsController(IBookCommentRepository db)
        {
            this.db = db;
        }



        // GET: BookComments
        public async Task<ActionResult> Index()
        {
            return View(await db.Get());
        }

        // GET: BookComments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookComment bookComment = await db.GetById(id);
            if (bookComment == null)
            {
                return HttpNotFound();
            }
            return View(bookComment);
        }

        // GET: BookComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookComments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,Description")] BookComment bookComment)
        {
            if (ModelState.IsValid)
            {
                await db.Insert(bookComment);
                return RedirectToAction("Index");
            }

            return View(bookComment);
        }

        // GET: BookComments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookComment bookComment = await db.GetById(id);
            if (bookComment == null)
            {
                return HttpNotFound();
            }
            return View(bookComment);
        }

        // POST: BookComments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,Description")] BookComment bookComment)
        {
            if (ModelState.IsValid)
            {
                await db.Update(bookComment);
                return RedirectToAction("Index");
            }
            return View(bookComment);
        }

        // GET: BookComments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookComment bookComment = await db.GetById(id);
            if (bookComment == null)
            {
                return HttpNotFound();
            }
            return View(bookComment);
        }

        // POST: BookComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BookComment bookComment = await db.GetById(id);
            await db.Delete(bookComment);
            return RedirectToAction("Index");
        }

      
    }
}
