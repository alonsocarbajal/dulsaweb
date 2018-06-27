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
        public virtual Cliente clientes { get; set; }
        [ForeignKey("EtapaId")]
        public virtual Etapa Etapas { get; set; }
        [ForeignKey("PrototipoId")]
        public virtual Prototipo prototipos { get; set; }
        [ForeignKey("LoteId")]
        public virtual Lote lotes { get; set; }
    }
}
