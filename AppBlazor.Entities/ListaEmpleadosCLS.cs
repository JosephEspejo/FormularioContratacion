 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class ListaEmpleadosCLS
    {
        public int Num_Empl { get; set; }
        public string Nombre { get; set; } = null!;

        public string sucursalEmpleado { get; set; } = string.Empty;
        public string directorEmpleado { get; set; } = string.Empty;

    }
}
