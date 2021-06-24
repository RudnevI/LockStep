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
    public class BookVotesController : Controller
    {
        private readonly IBookVoteRepository db;

        public BookVotesController(IBookVoteRepository db)
        {
            this.db = db;
        }



        // GET: BookVotes
        public async Task<ActionResult> Index()
        {
            return View(await db.Get());
        }

        // GET: BookVotes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVote bookVote = await db.GetById(id);
            if (bookVote == null)
            {
                return HttpNotFound();
            }
            return View(bookVote);
        }

        // GET: BookVotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookVotes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Value")] BookVote bookVote)
        {
            if (ModelState.IsValid)
            {
                await db.Insert(bookVote);
                return RedirectToAction("Index");
            }

            return View(bookVote);
        }

        // GET: BookVotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVote bookVote = await db.GetById(id);
            if (bookVote == null)
            {
                return HttpNotFound();
            }
            return View(bookVote);
        }

        // POST: BookVotes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Value")] BookVote bookVote)
        {
            if (ModelState.IsValid)
            {
                await db.Update(bookVote);
                return RedirectToAction("Index");
            }
            return View(bookVote);
        }

        // GET: BookVotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVote bookVote = await db.GetById(id);
            if (bookVote == null)
            {
                return HttpNotFound();
            }
            return View(bookVote);
        }

        // POST: BookVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BookVote bookVote = await db.GetById(id);
            await db.Delete(bookVote);
            return RedirectToAction("Index");
        }

      
    }
}
