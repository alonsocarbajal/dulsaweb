using System;
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

        public JsonResult GetLotesDisponibles(string descripcion)
        {
            Etapa etapa = null;
            if (!string.IsNullOrEmpty(descripcion))
            {
                etapa = db.Etapas.FirstOrDefault(e => e.Descripcion.Equals(descripcion));
            }
            IEnumerable<int> lotesDisponibles = new List<int>();
            ICollection<string> lotesOcupados = db.Etapas.Select(e => e.Lotes).ToList();
            foreach (var loteOcupado in lotesOcupados)
            {
                ICollection<int> lotesDisp = JsonConvert.DeserializeObject<ICollection<int>>(loteOcupado);
                lotesDisponibles = lotesDisponibles.Concat(lotesDisp);
            }
            var lotesSolicitud = etapa != null ? JsonConvert.DeserializeObject<ICollection<int>>(etapa.Lotes) : new List<int>();
            var lotesVendidos = db.Pagos.Include(p=>p.Lote).Select(p => p.Lote);
            return Json(new { lotesDisponibles, lotesSolicitud, lotesVendidos }, JsonRequestBehavior.AllowGet);
        }

        // GET: Etapas/Create
        public ActionResult Create(string id = null)
        {
            if (id == null)
                return View();
            else
            {
                var etapa = db.Etapas.Find(int.Parse(id));
                if (etapa == null)
                    return HttpNotFound();
                return View(etapa);//lote);
            }
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
                //Por aqui agarra cuando es un lote nuevo
                //Puesto que el id viene Vacio y se le crea uno nuevo
                if (etapa.Id == 0)
                {
                    db.Etapas.Add(etapa);
                    db.SaveChanges();
                }
                else
                {

                    db.Entry(etapa).State = EntityState.Modified;
                    db.SaveChanges();
                }
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
