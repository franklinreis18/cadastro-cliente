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
    public class acessosController : Controller
    {
        private dbContext db = new dbContext();

        // GET: acessoes
        [Authorize]
        
        public async Task<ActionResult> Index()
        {
            var acesso = db.acesso.Include(a => a.cliente).OrderBy(x => x.cliente.nomeCliente);
            return View(await acesso.ToListAsync());
        }
        [HttpPost]
        [Authorize]
       
        public async Task<ActionResult> Index(string texto)
        {
            var acesso = db.acesso.Where(x => x.cliente.nomeCliente.Contains(texto)).OrderBy(x => x.cliente.nomeCliente);
            return View(await acesso.ToListAsync());
        }
    
    // GET: acessoes/Details/5
    [Authorize]
    
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acesso acesso = await db.acesso.FindAsync(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }


        // GET: acessoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente");
            return View();
        }

        // POST: acessoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include = "idAcesso,idCliente,tipoAcesso,hostAcesso,usuarioAcesso,senhaAcesso,obsAcesso")] acesso acesso)
        {
            if (ModelState.IsValid)
            {
                db.acesso.Add(acesso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente", acesso.idCliente);
            return View(acesso);
        }

        // GET: acessoes/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acesso acesso = await db.acesso.FindAsync(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente", acesso.idCliente);
            return View(acesso);
        }

        // POST: acessoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "idAcesso,idCliente,tipoAcesso,hostAcesso,usuarioAcesso,senhaAcesso,obsAcesso")] acesso acesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acesso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "nomeCliente", acesso.idCliente);
            return View(acesso);
        }

        // GET: acessoes/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acesso acesso = await db.acesso.FindAsync(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // POST: acessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            acesso acesso = await db.acesso.FindAsync(id);
            db.acesso.Remove(acesso);
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
