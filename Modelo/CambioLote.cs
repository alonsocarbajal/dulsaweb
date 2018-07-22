using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("CambioLotes")]
    public class CambioLote
    {
        public int Id { get; set; }
        public int PagoId { get; set; }
        public int PaqueteObraId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }

        public virtual Pago Pago { get; set; }
    }
}
