﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Newtonsoft.Json;

namespace WebDulsa.Controllers
{
    public class EtapasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Etapas
        public ActionResult Index()
        {
            //var lista = new List<int>();
            //lista.Add(1);
            //lista.Add(2);
            //lista.Add(7);
            //lista.Add(10);
            ////db.Etapas.
            //var etapa = new Etapa()
            //{
            //    Descripcion = "Etapa 1",
            //    Lotes = JsonConvert.SerializeObject(lista)
            //};
            //db.Etapas.Add(etapa);
            //db.SaveChanges();
            return View(db.Etapas.ToList());
        }

        public JsonResult GetLotesDisponibles()
        {
            IEnumerable<int> lotesDisponibles = new List<int>();
            ICollection<string> disponibles = db.Etapas.Select(e => e.Lotes).ToList();
            foreach(var disponible in disponibles)
            {
                ICollection<int> lotesDisp= JsonConvert.DeserializeObject<ICollection<int>>(disponible);
                lotesDisponibles= lotesDisponibles.Concat(lotesDisp);
            }
            return Json(lotesDisponibles, JsonRequestBehavior.AllowGet);
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
        public ActionResult Create([Bind(Include = "Id,Descripcion,Lotes,Dalia,Azalea,Iris,Orquidea,Bugambilia,PrecioM2Excedente,MontoEsquina")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                if (etapa.Lotes.Length > 0)
                {
                    ICollection<int> lotesDisp = new List<int>();
                    var stringLotes = etapa.Lotes.Split(',');
                    foreach (var lote in stringLotes)
                        lotesDisp.Add(int.Parse(lote));
                    etapa.Lotes = JsonConvert.SerializeObject(lotesDisp);
                }
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