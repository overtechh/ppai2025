using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CierreOrdenApp.Entidades
{
    public class EstacionSismologica
    {
        public string Nombre { get; set; }
        public Sismografo Sismografo { get; set; }

        public bool EsDeEstacionSismologica() => true; // lógica si la necesitás
    }
}

