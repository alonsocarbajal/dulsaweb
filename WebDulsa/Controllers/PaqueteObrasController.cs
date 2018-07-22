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
    [Authorize]
    public class PaqueteObrasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: PaqueteObras
        public ActionResult Index()
        {
            return View(db.PaqueteObras.ToList());
        }

        // GET: PaqueteObras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaqueteObra paqueteObra = db.PaqueteObras.Find(id);
            if (paqueteObra == null)
            {
                return HttpNotFound();
            }
            return View(paqueteObra);
        }

        // GET: PaqueteObras/Create
        public ActionResult Create(string id = null)
        {
            if (id == null)
               return View();
            else
            {
                var paquete = db.PaqueteObras.Find(int.Parse(id));
                if (paquete == null)
                    return HttpNotFound();
                return View(paquete);//lote);
            }
        }

        // POST: PaqueteObras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Concepto,Tipo,Precio")] PaqueteObra paqueteObra)
        {
            if (ModelState.IsValid)
            {
                if (paqueteObra.Id == 0)
                {
                    db.PaqueteObras.Add(paqueteObra);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(paqueteObra).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }

            return View(paqueteObra);
        }

        // GET: PaqueteObras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaqueteObra paqueteObra = db.PaqueteObras.Find(id);
            if (paqueteObra == null)
            {
                return HttpNotFound();
            }
            return View(paqueteObra);
        }

        // POST: PaqueteObras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Concepto,Tipo,Precio")] PaqueteObra paqueteObra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paqueteObra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paqueteObra);
        }

        // GET: PaqueteObras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaqueteObra paqueteObra = db.PaqueteObras.Find(id);
            if (paqueteObra == null)
            {
                return HttpNotFound();
            }
            return View(paqueteObra);
        }

        // POST: PaqueteObras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaqueteObra paqueteObra = db.PaqueteObras.Find(id);
            db.PaqueteObras.Remove(paqueteObra);
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
