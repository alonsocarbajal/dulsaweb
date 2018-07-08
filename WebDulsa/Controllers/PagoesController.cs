using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;

namespace WebDulsa.Controllers
{
    public class PagoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pagoes
        public ActionResult Index()
        {
            var pagos = db.Pagos.Include(p => p.Asesor).Include(p => p.Cliente).Include(p => p.Lote).Include(p => p.Prototipo);
            return View(pagos.ToList());
        }

        // GET: Pagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: Pagoes/Create
        public ActionResult Create()
        {
            ViewBag.AsesorId = new SelectList(db.Asesores, "Id", "Nombre");
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre");
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Descripcion");
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,LoteId,PrototipoId,Fecha,MontoApartado,Credito,Banco,Vigencia,MontoEnganche,Pago1,ImportePago1,Pago2,ImportePago2,Pago3,ImportePago3,Pago4,ImportePago4,Pago5,ImportePago5,Cambios,AsesorId,Observaciones")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Pagos.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsesorId = new SelectList(db.Asesores, "Id", "Nombre", pago.AsesorId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Descripcion", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", pago.PrototipoId);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsesorId = new SelectList(db.Asesores, "Id", "Nombre", pago.AsesorId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Descripcion", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", pago.PrototipoId);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,LoteId,PrototipoId,Fecha,MontoApartado,Credito,Banco,Vigencia,MontoEnganche,Pago1,ImportePago1,Pago2,ImportePago2,Pago3,ImportePago3,Pago4,ImportePago4,Pago5,ImportePago5,Cambios,AsesorId,Observaciones")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsesorId = new SelectList(db.Asesores, "Id", "Nombre", pago.AsesorId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Descripcion", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", pago.PrototipoId);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pago pago = db.Pagos.Find(id);
            db.Pagos.Remove(pago);
            db.SaveChanges();
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
