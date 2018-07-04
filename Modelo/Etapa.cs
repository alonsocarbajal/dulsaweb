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
            this.ListaVenta = new HashSet<ListaVenta>();
            this.Pago = new HashSet<Pago>();
            //this.Lote = new HashSet<Lote>();
        }
        
        public int Id { get; set; }
        public int Descripcion { get; set; }

        public virtual ICollection<ListaVenta> ListaVenta { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
        //public virtual ICollection<Lote> Lote { get; set; }
    }
}
