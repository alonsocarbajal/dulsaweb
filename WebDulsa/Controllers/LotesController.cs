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
    public class LotesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lotes
        public ActionResult Index()
        {
            return View(db.Lotes.ToList());
        }

        // GET: Lotes/Create
        public ActionResult Create(string id = null)
        {
            if (id == null)
                return View();
            else
            {
                var lote = db.Lotes.Find(int.Parse(id));
                if (lote == null)
                    return HttpNotFound();
                return View(lote);//lote);
            }
        }

        // POST: Lotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Manzana,M2Terreno,ExcedenteM2,Esquina")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                //Por aqui agarra cuando es un lote nuevo
                //Puesto que el id viene Vacio y se le crea uno nuevo
                if (lote.Id == 0)
                {
                    db.Lotes.Add(lote);
                    db.SaveChanges();
                } else
                {
                    db.Entry(lote).State = EntityState.Modified;
                    db.SaveChanges();
                }
                //db.Lotes.Add(lote);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lote);
        }
        // GET: Lotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lotes.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lote lote = db.Lotes.Find(id);
            db.Lotes.Remove(lote);
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
