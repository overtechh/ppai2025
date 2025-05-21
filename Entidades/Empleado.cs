using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CierreOrdenApp.Entidades
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public bool EsResponsableDeReparacion() => Rol == "Reparacion";
    }
}


