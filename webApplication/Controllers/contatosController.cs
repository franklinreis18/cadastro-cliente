using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webApplication.Models;

namespace webApplication.Controllers
{
    public class contatosController : Controller
    {
        private dbContext db = new dbContext();

        // GET: contatoes
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var contato = db.contato.Include(c => c.cliente);
            return View(await contato.ToListAsync());
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Index(string texto)
        {
            var contato = db.contato.Where(x => x.cliente.nomeCliente.Contains(texto)).OrderBy(x => x.cliente.nomeCliente);
            return View(await contato.ToListAsync());
        }
        // GET: contatoes/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contato contato = await db.contato.FindAsync(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: contatoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente");
            return View();
        }

        // POST: contatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include = "idContato,idCliente,nomeContato,setorContato,telefoneContato,emailContato")] contato contato)
        {
            if (ModelState.IsValid)
            {
                db.contato.Add(contato);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente", contato.idCliente);
            return View(contato);
        }

        // GET: contatoes/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contato contato = await db.contato.FindAsync(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente", contato.idCliente);
            return View(contato);
        }

        // POST: contatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "idContato,idCliente,nomeContato,setorContato,telefoneContato,emailContato")] contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente", contato.idCliente);
            return View(contato);
        }

        // GET: contatoes/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contato contato = await db.contato.FindAsync(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: contatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            contato contato = await db.contato.FindAsync(id);
            db.contato.Remove(contato);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
