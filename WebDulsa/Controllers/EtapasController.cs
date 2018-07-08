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
    public class EtapasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Etapas
        public ActionResult Index()
        {
            return View(db.Etapas.ToList());
        }

        // GET: Etapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // GET: Etapas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Lote1,Lote2,Lote3,Lote4,Lote5,Lote6,Lote7,Lote8,Lote9,Lote10,Lote11,Lote12,Lote13,Lote14,Lote15,Lote16,Lote17,Lote18,Lote19,Lote20,Lote21,Lote22,Lote23,Lote24,Dalia,Azalea,Iris,Orquidea,Bugambilia,PrecioM2Excedente,MontoEsquina")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Etapas.Add(etapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etapa);
        }

        // GET: Etapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Etapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Lote1,Lote2,Lote3,Lote4,Lote5,Lote6,Lote7,Lote8,Lote9,Lote10,Lote11,Lote12,Lote13,Lote14,Lote15,Lote16,Lote17,Lote18,Lote19,Lote20,Lote21,Lote22,Lote23,Lote24,Dalia,Azalea,Iris,Orquidea,Bugambilia,PrecioM2Excedente,MontoEsquina")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etapa);
        }

        // GET: Etapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etapa etapa = db.Etapas.Find(id);
            db.Etapas.Remove(etapa);
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
