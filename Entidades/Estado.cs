using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CierreOrdenApp.Entidades
{
    public class Estado
    {
        public string Tipo { get; set; } // Ej: "Fuera de Servicio"
        public string Motivos { get; set; } // Texto con todos los motivos
        public string Responsable { get; set; } // Nombre del RI (placeholder por ahora)
        public DateTime FechaHora { get; set; }

        public override string ToString()
        {
            return $"{Tipo} | {FechaHora:dd/MM/yyyy HH:mm:ss} | {Motivos} | Responsable: {Responsable}";
        }
    }
}

