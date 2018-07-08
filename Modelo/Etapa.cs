using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Etapas")]
    public class Etapa
    {
        public Etapa()
        {
            //this.ListaVenta = new HashSet<ListaVenta>();
            //this.Pago = new HashSet<Pago>();
            //this.Lote = new HashSet<Lote>();
        }
        
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Lotes { get; set; }
        public Nullable<decimal> Dalia { get; set; }
        public Nullable<decimal> Azalea { get; set; }
        public Nullable<decimal> Iris { get; set; }
        public Nullable<decimal> Orquidea { get; set; }
        public Nullable<decimal> Bugambilia { get; set; }
        public Nullable<decimal> PrecioM2Excedente { get; set; }
        public Nullable<decimal> MontoEsquina { get; set; }

        //public virtual ICollection<ListaVenta> ListaVenta { get; set; }
        //public virtual ICollection<Pago> Pago { get; set; }
        //public virtual ICollection<Lote> Lote { get; set; }
    }
}
