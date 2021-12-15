using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPFF.Models
{
    public class Tarifa
    {
        public int TarifaId { get; set; }
        public string Duracion { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public virtual List<Actividad> Actividades { get; set; }
    }
}
