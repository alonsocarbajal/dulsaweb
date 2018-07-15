using System;
using System.Collections.Generic;
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
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
    }
}
