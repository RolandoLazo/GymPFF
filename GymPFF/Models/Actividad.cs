using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPFF.Models
{
    public class Actividad
    {
        public int ActividadId { get; set; }
        public string NombreActividad { get; set; }
        public string Descripcion { get; set; }
        public int TarifaId { get; set; }
        public virtual Tarifa Tarifa { get; set; }

        public virtual List<Clase> Clases { get; set; }
    }
}
