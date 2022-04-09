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
    public class ErrosController : Controller
    {
        private dbContext db = new dbContext();

        [Authorize]
        // GET: Erros
        public async Task<ActionResult> Index()
        {
            return View(await db.Erroes.ToListAsync());
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Index(string texto) {
            var errosMessage = db.Erroes.Where(x => x.Message.Contains(texto) || x.Trace.Contains(texto) || x.Stack.Contains(texto)).OrderBy(x => x.Message);
            return View(await errosMessage.ToListAsync());
        }

        // GET: Erros/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Erro erro = await db.Erroes.FindAsync(id);
            if (erro == null)
            {
                return HttpNotFound();
            }
            return View(erro);
        }

        // GET: Erros/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Erros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include = "IdErro,Message,Stack,Trace,Done,Solution,Type")] Erro erro)
        {
            if (ModelState.IsValid)
            {
                db.Erroes.Add(erro);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(erro);
        }

        // GET: Erros/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Erro erro = await db.Erroes.FindAsync(id);
            if (erro == null)
            {
                return HttpNotFound();
            }
            return View(erro);
        }

        // POST: Erros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "IdErro,Message,Stack,Trace,Done,Solution,type")] Erro erro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(erro).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(erro);
        }

        // GET: Erros/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Erro erro = await db.Erroes.FindAsync(id);
            if (erro == null)
            {
                return HttpNotFound();
            }
            return View(erro);
        }

        // POST: Erros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Erro erro = await db.Erroes.FindAsync(id);
            db.Erroes.Remove(erro);
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
