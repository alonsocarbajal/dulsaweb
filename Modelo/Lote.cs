using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Lotes")]
    public class Lote
    {
        public Lote()
        {
            this.Pago = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public int Descripcion { get; set; }
        public int Manzana { get; set; }
        public int EtapaId { get; set; }
        public Nullable<decimal> M2 { get; set; }
        public Nullable<decimal> M2Excedente { get; set; }
        public Nullable<decimal> ImporteExcedente { get; set; }
        public Nullable<decimal> Esquina { get; set; }
        public Nullable<decimal> ImporteTotal { get; set; }
        public char Estatus { get; set; }

        [ForeignKey("EtapaId")]
        public virtual Etapa Etapas { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }

    }
}
