using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Contexto: DbContext
    {

        public Contexto()
            //: base("data source = sql5004.site4now.net; user id = DB_A28A96_AlonsoDB_admin; password=Master20145;MultipleActiveResultSets=True;")
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Asesor> Asesores { get; set; }
        public virtual DbSet<Prototipo> Prototipos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Etapa> Etapas { get; set; }
        public virtual DbSet<ListaVenta> ListaVentas { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Lote> Lotes { get; set; }
        public virtual DbSet<CambioLote> CambiosLote { get; set; }

        public DbSet<Modelo.PaqueteObra> PaqueteObras { get; set; }
    }
}
