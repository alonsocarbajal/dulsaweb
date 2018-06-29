using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Pagos")]
    public  class Pago
    {
        public int Id { get; set; }
        public int EtapaId { get; set; }
        public int ClienteId { get; set; }
        public int LoteId { get; set; }
        public int PrototipoId { get; set; }
        public DateTime Fecha { get; set; }
        public char Estatus { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public string Concepto { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("EtapaId")]
        public virtual Etapa Etapa { get; set; }
        [ForeignKey("PrototipoId")]
        public virtual Prototipo Prototipo { get; set; }
        [ForeignKey("LoteId")]
        public virtual Lote Lote { get; set; }
    }
}
