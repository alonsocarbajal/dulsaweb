using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("ListaVenta")]
    public class ListaVenta
    {
        public int Id { get; set; }
        public int PrototipoId { get; set; }
        public int EtapaId { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public char Estatus { get; set; }

        [ForeignKey("EtapaId")]
        public virtual Etapa Etapas { get; set; }
        [ForeignKey("PrototipoId")]
        public virtual Prototipo Prototipos { get; set; }

    }
}
