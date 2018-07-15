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
    public class AsesoresController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Asesors
        public ActionResult Index()
        {
            return View(db.Asesores.ToList());
        }
        
        // GET: Asesors/Create
        public ActionResult Create(string id= null)
        {
            if (id == null)
                return View();
            else
            {
                var asesor = db.Asesores.Find(int.Parse(id));
                if (asesor == null)
                    return HttpNotFound();
                return View(asesor);//lote);
            }
        }

        // POST: Asesors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono")] Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                //Por aqui agarra cuando es un lote nuevo
                //Puesto que el id viene Vacio y se le crea uno nuevo
                if (asesor.Id == 0)
                {
                    db.Asesores.Add(asesor);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(asesor).State = EntityState.Modified;
                    db.SaveChanges();
                }
                //db.Lotes.Add(lote);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asesor);
        }

        // GET: Asesors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesor asesor = db.Asesores.Find(id);
            if (asesor == null)
            {
                return HttpNotFound();
            }
            return View(asesor);
        }

        // POST: Asesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asesor asesor = db.Asesores.Find(id);
            db.Asesores.Remove(asesor);
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
