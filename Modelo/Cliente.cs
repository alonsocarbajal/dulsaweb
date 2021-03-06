﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Nombre { get; set; }
        public string Regimen { get; set; }
        public string Nacionalidad { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        [Display(Description ="Tel Casa")]
        public string TelefonoCasa { get; set; }
        [Display(Description = "Tel Cel")]
        public string TelefonoCelular { get; set; }
        [Display(Description = "Tel Oficina")]
        public string TelefonoOficina { get; set; }
        public string Email { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string Empresa { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Introduzca un valor valido")]
        public decimal Sueldo { get; set; }
        public string Beneficiario { get; set; }
        [Required]
        public string AqueSeDedica { get; set; }
        public string OpcionMkt { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string PropositoCompra { get; set; }
        public string HabitaCasa { get; set; }
        public string FuenteProspeccion { get; set; }
        public string Referencia1 { get; set; }
        public string TelReferencia1 { get; set; }
        public string Referencia2 { get; set; }
        public string TelReferencia2 { get; set; }
        public string Referencia3 { get; set; }
        public string TelReferencia3 { get; set; }
        public string FormaPago { get; set; }

        public virtual ICollection<Pago> Pago { get; set; }
    }
}
