using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPFF.Models
{
    public class RayosUV
    {
        public int RayosUVId { get; set; }
        public int NumCuarto { get; set; }
        public string HoraUso { get; set; }

        public virtual List<Cliente> Clientes { get; set; }
    }
}
