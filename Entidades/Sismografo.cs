using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CierreOrdenApp.Entidades
{
    public class Sismografo
    {
        public string Identificador { get; set; }
        public List<Estado> HistorialEstados { get; set; } = new();

        public void ActualizarEstado(string tipo, List<MotivoTipo> motivos, string responsable)
        {
            var estado = new Estado
            {
                Tipo = tipo,
                Motivos = string.Join(" | ", motivos),
                Responsable = responsable,
                FechaHora = DateTime.Now
            };

            HistorialEstados.Add(estado);
        }



        public Estado ObtenerUltimoEstado() => HistorialEstados.LastOrDefault();
        public bool EsFueraDeServicio()
        {
            return ObtenerUltimoEstado()?.Tipo == "Fuera de Servicio";
        }


    }
}

