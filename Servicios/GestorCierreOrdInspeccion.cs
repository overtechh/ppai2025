using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CierreOrdenApp.Entidades;

namespace CierreOrdenApp.Servicios
{
    public class GestorCierreOrdInspeccion
    {
        public List<OrdenInspeccion> BuscarOrdenesPendientes(List<OrdenInspeccion> todas)
        {
            return todas
                .Where(o => o.EsRealizada())
                .OrderByDescending(o => o.FechaFinalizacion)
                .ToList();
        }

        public void CerrarOrden(
            OrdenInspeccion orden,
            List<MotivoTipo> motivos,
            string observacion,
            string responsable)

        {
            orden.EstaCerrada = true;
            orden.FechaCierre = DateTime.Now;

            orden.EstacionSismologica.Sismografo.ActualizarEstado(
                "Fuera de Servicio",
                motivos,
                responsable
            );
        }

        public void NotificarPorMail(
             Sismografo sismografo,
             List<MotivoTipo> motivos,
             string responsable,
             List<Empleado> empleados)

        {
            string cuerpo = $"[NOTIFICACIÓN - ESTADO FUERA DE SERVICIO]\n" +
                            $"Sismógrafo: {sismografo.Identificador}\n" +
                            $"Estado: Fuera de Servicio\n" +
                            $"Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                            $"Motivos y comentarios:\n  - {string.Join("\n  - ", motivos)}\n" +
                            $"Responsable: {responsable}\n";

            var destinatarios = empleados.Where(e => e.EsResponsableDeReparacion());

            foreach (var emp in destinatarios)
            {
                // Simular envío por consola
                Console.WriteLine($"📧 Mail a {emp.Email}:\n{cuerpo}");

                // Simular registro en archivo
                File.AppendAllText("notificaciones_email.txt", $"Para: {emp.Email}\n{cuerpo}\n------------------------\n");
            }

            // Simular publicación en CCRS (archivo)
            File.AppendAllText("publicaciones_CCRS.txt", $"[PUBLICADO EN CCRS]\n{cuerpo}\n\n");
        }

    }
}


