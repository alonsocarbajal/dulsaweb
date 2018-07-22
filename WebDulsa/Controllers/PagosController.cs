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
    public class PagosController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Pagoes
        public ActionResult Index()
        {
            var pagos = db.Pagos.Include(p => p.Asesor).Include(p => p.Cliente).Include(p => p.Lote);
            return View(pagos.ToList());
        }
        //[HttpPost]
        //public JsonResult GetInfo(int loteId=null, )
        //{

        //}

        public JsonResult GetEtapa(int loteId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var lote =db.Lotes.Find(loteId);
            dynamic resultado = null;
            //var lote = db.Lotes.FirstOrDefault(l => l.Id == loteId); //!= null ? db.Lotes.FirstOrDefault(l => l.Id == loteId).ExcedenteM2 : 0;
            var lista = db.Etapas.ToList().Select(x => new
            {
                x.Id,
                x.Dalia,
                x.Azalea,
                x.Bugambilia,
                x.Iris,
                x.PrecioM2Excedente,
                x.Orquidea,
                x.MontoEsquina,
                EsEsquina = lote != null ? lote.Esquina : false,
                Lotes = JsonConvert.DeserializeObject<IEnumerable<int>>(x.Lotes),
                MtsExcedente=lote !=null ? lote.ExcedenteM2: 0
            });
            foreach (var item in lista)
            {
                foreach(var t in item.Lotes)
                {
                   if( t.ToString().Equals(lote.Descripcion))
                   {
                        resultado = item;
                   }
                }
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPrototipo(string descripcion)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (string.IsNullOrEmpty(descripcion))
                return Json(0, JsonRequestBehavior.AllowGet);
            var prototipo= db.Prototipos.Where(p => p.Descripcion.Equals(descripcion)).OrderByDescending(p => p.Version).FirstOrDefault();
            return Json(prototipo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPaqueteObras(string descripcion)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //if (string.IsNullOrEmpty(descripcion))
            //    return Json(0, JsonRequestBehavior.AllowGet);
            var paquetes = db.PaqueteObras.ToList();
            return Json(paquetes, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPrototipoId(string descripcion)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Prototipos.FirstOrDefault(p => p.Descripcion.ToLower().Equals(descripcion)).Id, JsonRequestBehavior.AllowGet);
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
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Descripcion", "Descripcion");
            ViewBag.MiBanco = ObtenerBanco();
            ViewBag.MiCredito = ObtenerCredito();
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,LoteId,PrototipoId,Fecha,MontoApartado,Credito,Banco,Vigencia,MontoEnganche,Pago1,ImportePago1,Pago2,ImportePago2,Pago3,ImportePago3,Pago4,ImportePago4,Pago5,ImportePago5,Cambios,AsesorId,Observaciones")] Pago pago)
        {
            //if(ModelState.FirstOrDefault(p=>p.Key.Contains()))
            //    ModelState.is
            if (ModelState.IsValid)
            {
                //pago.PrototipoId = db.Prototipos.FirstOrDefault(p => p.Descripcion.ToLower().Equals(pago.PrototipoId)).Id;
                db.Pagos.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsesorId = new SelectList(db.Asesores, "Id", "Nombre", pago.AsesorId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Descripcion", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Descripcion", "Descripcion", pago.PrototipoId);
            ViewBag.MiBanco = ObtenerBanco();
            ViewBag.MiCredito = ObtenerCredito();
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            id =id?? 0;
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                pago = new Pago();
            }
            ViewBag.AsesorId = new SelectList(db.Asesores, "Id", "Nombre", pago.AsesorId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Descripcion", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", pago.PrototipoId);
            ViewBag.MiBanco = ObtenerBanco();
            ViewBag.MiCredito = ObtenerCredito();

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

        public List<SelectListItem> ObtenerBanco()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="BANAMEX",
                    Value="BANAMEX"
                },
                new SelectListItem()
                {
                    Text="BBVA BANCOMER",
                    Value="BBVA BANCOMER"
                },
                new SelectListItem()
                {
                    Text="SANTANDER",
                    Value="SANTANDER"
                },
                new SelectListItem()
                {
                    Text="BANORTE",
                    Value="BANORTE"
                },
                new SelectListItem()
                {
                    Text="SCOTIABANK",
                    Value="SCOTIABANK"
                },
                new SelectListItem()
                {
                    Text="HSBC",
                    Value="HSBC"
                },
                new SelectListItem()
                {
                    Text="BAJIO",
                    Value="BAJIO"
                },
                new SelectListItem()
                {
                    Text="OTRO",
                    Value="OTRO"
                }
            };
        }

        public List<SelectListItem> ObtenerCredito()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="BANCARIO",
                    Value="BANCARIO"
                },
                new SelectListItem()
                {
                    Text="INFONAVIT",
                    Value="INFONAVIT"
                },
                new SelectListItem()
                {
                    Text="COFI",
                    Value="COFI"
                },
                new SelectListItem()
                {
                    Text="FOVISSSTE",
                    Value="FOVISSSTE"
                },
                new SelectListItem()
                {
                    Text="ALIADOS",
                    Value="ALIADOS"
                },
                new SelectListItem()
                {
                    Text="CONTADO",
                    Value="CONTADO"
                },
                new SelectListItem()
                {
                    Text="PEMEX",
                    Value="PEMEX"
                },
                new SelectListItem()
                {
                    Text="OTRO",
                    Value="OTRO"
                }
            };
        }
    }
}
