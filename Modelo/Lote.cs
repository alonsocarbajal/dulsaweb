using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Descripcion { get; set; }
        public int Manzana { get; set; }
        [Required]
        public Nullable<decimal> M2Terreno { get; set; }
        [Required]
        public Nullable<decimal> ExcedenteM2 { get; set; }
        public Boolean Esquina { get; set; }
        
        
        public virtual ICollection<Pago> Pago { get; set; }

    }
}
