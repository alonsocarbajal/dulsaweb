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
    public class ClientesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }
        
        // GET: Clientes/Create
        public ActionResult Create(string id = null)
        {
            if (id == null)
            {
                ViewBag.MiRegimen = ObtenerRegimen();
                ViewBag.MiNacionalidad = ObtenerNacionalidad();
                return View();
            }
            else
            {
                var cliente = db.Clientes.Find(int.Parse(id));
                if (cliente == null)
                    return HttpNotFound();
                ViewBag.MiRegimen = ObtenerRegimen();
                ViewBag.MiNacionalidad = ObtenerNacionalidad();
                return View(cliente);
            }
            
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Regimen,Nacionalidad,Ciudad,Colonia,Calle,Numero,TelefonoCasa,TelefonoCelular,TelefonoOficina,Email,Rfc,Curp,FechaNacimiento,LugarNacimiento,Empresa,Sueldo,Beneficiario, OpcionMkt,AqueSeDedica,EstadoCivil,Sexo,PropositoCompra,HabitaCasa,FuenteProspeccion,Referencia1,TelReferencia1,Referencia2,TelReferencia2,Referencia3,TelReferencia3,FormaPago")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id == 0)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.MiRegimen = ObtenerRegimen();
            ViewBag.MiNacionalidad = ObtenerNacionalidad();
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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

        public List<SelectListItem> ObtenerRegimen()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="SOLTERO",
                    Value="SOLTERO"
                },
                new SelectListItem()
                {
                    Text="BIENES MANCOMUNADOS",
                    Value="BIENES MANCOMUNADOS"
                },
                new SelectListItem()
                {
                    Text="SEPARACION DE BIENES",
                    Value="SEPARACION DE BIENES"
                }
            };
        }

        public List<SelectListItem> ObtenerNacionalidad()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="MEXICANA",
                    Value="MEXICANA"
                },
                new SelectListItem()
                {
                    Text="EXTRANJERO",
                    Value="EXTRANJERO"
                },
             };
        }
    }
}
