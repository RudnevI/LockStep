using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LockStep.Library.Domain.Finance;
using LockStep.Library.Persistence;

namespace LockStep.Web.Controllers
{
    public class PricesController : Controller
    {
        private readonly IPriceRepository repo;

        public PricesController(IPriceRepository repo)
        {
            this.repo = repo;
        }



        // GET: Prices
        public async Task<ActionResult> Index()
        {
            return View(await repo.Get());
        }

        // GET: Prices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = await repo.GetById(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Value,From,To")] Price price)
        {
            if (ModelState.IsValid)
            {
                await repo.Insert(price);
                return RedirectToAction("Index");
            }

            return View(price);
        }

        // GET: Prices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = await repo.GetById(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Value,From,To")] Price price)
        {
            if (ModelState.IsValid)
            {
                await repo.Update(price);
                return RedirectToAction("Index");
            }
            return View(price);
        }

        // GET: Prices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = await repo.GetById(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Price price = await repo.GetById(id);
            await repo.Delete(price);
            return RedirectToAction("Index");
        }

 
    }
}
