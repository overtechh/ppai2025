using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CierreOrdenApp.Entidades
{
    public class OrdenInspeccion
    {
        public Empleado Responsable { get; set; }

        public bool EsDeEmpleado(Empleado e)
        {
            return Responsable?.Email == e?.Email;
        }

        public string Id { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public DateTime? FechaCierre { get; set; } // nullable por si aún no fue cerrada

        public EstacionSismologica EstacionSismologica { get; set; }
        public bool EstaCerrada { get; set; }

        public bool EsRealizada()
        {
            // Asumimos que una orden está "realizada" si no está cerrada aún
            return !EstaCerrada;
        }

        public string ObtenerInfo()
        {
            return $"#{Id} - {FechaFinalizacion:dd/MM/yyyy} - {EstacionSismologica.Nombre} - Sismógrafo {EstacionSismologica.Sismografo.Identificador}";
        }

        public override string ToString()
        {
            return ObtenerInfo();
        }
    }
}



