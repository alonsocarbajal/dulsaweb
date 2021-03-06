﻿using System;
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
    public class PrototiposController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Prototipos
        public ActionResult Index()
        {
            return View(db.Prototipos.ToList());
        }
        
        // GET: Prototipos/Create
        public ActionResult Create()
        {
            ViewBag.MisPrototipos = ObtenerPrototipos();
            return View();
        }

        // POST: Prototipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,MetrosCuadrado,Version")] Prototipo prototipo)
        {
            if (ModelState.IsValid)
            {
                db.Prototipos.Add(prototipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prototipo);
        }

        // GET: Prototipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prototipo prototipo = db.Prototipos.Find(id);
            if (prototipo == null)
            {
                return HttpNotFound();
            }
            return View(prototipo);
        }

        // POST: Prototipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prototipo prototipo = db.Prototipos.Find(id);
            db.Prototipos.Remove(prototipo);
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

        public List<SelectListItem> ObtenerPrototipos()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="AZALEA",
                    Value="AZALEA"
                },
                new SelectListItem()
                {
                    Text="BUGAMBILIA",
                    Value="BUGAMBILIA"
                },
                new SelectListItem()
                {
                    Text="DALIA",
                    Value="DALIA"
                },
                new SelectListItem()
                {
                    Text="IRIS",
                    Value="IRIS"
                },
                new SelectListItem()
                {
                    Text="ORQUIDEA",
                    Value="ORQUIDEA"
                }

            };
        }

        [HttpGet]
        public JsonResult GetPrototipo(string Descripcion)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var prototipo = db.Prototipos.Where(p=>p.Descripcion.Equals(Descripcion)).OrderByDescending(p=>p.Version).FirstOrDefault();
            if (prototipo == null)
                return Json("No Existe");
            else
                return Json(prototipo, JsonRequestBehavior.AllowGet);
        }
    }
}
