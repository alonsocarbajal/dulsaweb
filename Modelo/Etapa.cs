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
        public int Descripcion { get; set; }
        public Boolean Lote1 { get; set; }
        public Boolean Lote2 { get; set; }
        public Boolean Lote3 { get; set; }
        public Boolean Lote4 { get; set; }
        public Boolean Lote5 { get; set; }
        public Boolean Lote6 { get; set; }
        public Boolean Lote7 { get; set; }
        public Boolean Lote8 { get; set; }
        public Boolean Lote9 { get; set; }
        public Boolean Lote10 { get; set; }
        public Boolean Lote11 { get; set; }
        public Boolean Lote12 { get; set; }
        public Boolean Lote13 { get; set; }
        public Boolean Lote14 { get; set; }
        public Boolean Lote15 { get; set; }
        public Boolean Lote16 { get; set; }
        public Boolean Lote17 { get; set; }
        public Boolean Lote18 { get; set; }
        public Boolean Lote19 { get; set; }
        public Boolean Lote20 { get; set; }
        public Boolean Lote21 { get; set; }
        public Boolean Lote22 { get; set; }
        public Boolean Lote23 { get; set; }
        public Boolean Lote24 { get; set; }
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
