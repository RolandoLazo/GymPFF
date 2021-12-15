using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPFF.Models
{
    public class Clase
    {
        public int ClaseId { get; set; }
        public string DiaEstablecido { get; set; }
        public string HInicio { get; set; }
        public int SalaId { get; set; }
        public virtual Sala Sala { get; set; }
        public int ActividadId { get; set; }
        public virtual Actividad Actividad { get; set; }
        public int EmpleadoId { get; set; }
        public virtual Empleado Empleado { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
