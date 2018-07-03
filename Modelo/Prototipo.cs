using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Prototipos")]
    public class Prototipo
    {
        public Prototipo()
        {
            this.ListaVenta = new HashSet<ListaVenta>();
            this.Pago = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> MetrosCuadrado { get; set; }
        public Nullable<decimal> Version { get; set; }

        public virtual ICollection<ListaVenta> ListaVenta { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
