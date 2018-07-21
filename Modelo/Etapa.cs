using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage ="La etapa es requerida")]
        public string Descripcion { get; set; }
        public string Lotes { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Dalia { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Azalea { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Iris { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Orquidea { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Bugambilia { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal PrecioM2Excedente { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal MontoEsquina { get; set; }
    }
}
