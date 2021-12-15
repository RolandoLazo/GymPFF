using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPFF.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidosCompletos { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public string PuestoEmpleado { get; set; }
        public string SeguroCCSS { get; set; }
        public string PolizaINS { get; set; }
        public string CuentaBanco { get; set; }
        public string RetencionCCSS { get; set; }
        public int SalarioNeto { get; set; }

        public virtual List<Clase> Clases { get; set; }
    }
}
