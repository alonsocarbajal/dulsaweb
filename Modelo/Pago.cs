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
        public int ClienteId { get; set; }
        public int LoteId { get; set; }
        public string PrototipoId { get; set; }
        public DateTime Fecha { get; set; }
        public Nullable<decimal> MontoApartado { get; set; }
        public string Credito { get; set; }
        public string Banco { get; set; }
        public DateTime Vigencia { get; set; }
        public Nullable<decimal> MontoEnganche { get; set; }
        public DateTime Pago1 { get; set; }
        public Nullable<decimal> ImportePago1 { get; set; }
        public DateTime Pago2 { get; set; }
        public Nullable<decimal> ImportePago2 { get; set; }
        public DateTime Pago3 { get; set; }
        public Nullable<decimal> ImportePago3 { get; set; }
        public DateTime Pago4 { get; set; }
        public Nullable<decimal> ImportePago4 { get; set; }
        public DateTime Pago5 { get; set; }
        public Nullable<decimal> ImportePago5 { get; set; }
        public Boolean Cambios { get; set; }
        public int AsesorId { get; set; }
        public string Observaciones { get; set; }


        //[ForeignKey("PrototipoId")]
        //public virtual Prototipo Prototipo { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("AsesorId")]
        public virtual Asesor Asesor { get; set; }
        [ForeignKey("LoteId")]
        public virtual Lote Lote { get; set; }
    }
}
