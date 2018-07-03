using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Clientes")]
    public class Cliente
    {

        public Cliente()
        {
            this.Pago = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Regimen { get; set; }
        public string Nacionalidad { get; set; }
        public string Rfc { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoOficina { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public int Cambio { get; set; }
        public Nullable<Decimal> Sueldo { get; set; }
        public string Beneficiario { get; set; }

        public virtual ICollection<Pago> Pago { get; set; }
    }
}
