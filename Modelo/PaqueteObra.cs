using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("PaquetesObra")]
    public class PaqueteObra
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public string Tipo { get; set; }
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Precio { get; set; }
    }
}
