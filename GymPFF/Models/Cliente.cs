using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPFF.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }

        public string ApellidosCompleto { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public DateTime FRenovacion { get; set; }
        public int RayosUVId { get; set; }
        public virtual RayosUV RayosUV { get; set; }
        public virtual List<Clase> Clases { get; set; }
    }
}
