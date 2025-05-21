// ✔️ Pone esto al principio del archivo:
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using CierreOrdenApp.Entidades;
using CierreOrdenApp.Sesiones;
using CierreOrdenApp.Servicios;




namespace CierreOrdenApp
{
    public partial class Form1 : Form
    {
        private List<OrdenInspeccion> ordenesPendientes = new();

        public Form1()
        {
            InitializeComponent();
        }
        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            string ruta = "historial_cierres.txt";

            if (!File.Exists(ruta))
            {
                MessageBox.Show("Aún no hay historial registrado.", "Historial vacío");
                return;
            }

            string contenido = File.ReadAllText(ruta);
            MessageBox.Show(contenido, "Historial de cierres", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Sesion.UsuarioActual = new Empleado
            {
                Nombre = "Facundo Rueda",
                Email = "facundo@ri.com",
                Rol = "ResponsableInspecciones"
            };

            // 🔄 Limpiar archivos de historial y notificaciones al iniciar
            File.WriteAllText("historial_cierres.txt", string.Empty);
            File.WriteAllText("notificaciones_email.txt", string.Empty);
            File.WriteAllText("publicaciones_CCRS.txt", string.Empty);

            // 📋 Cargar órdenes iniciales
            ordenesPendientes = new List<OrdenInspeccion>
{
    new OrdenInspeccion
    {
        Id = "001",
        FechaFinalizacion = new DateTime(2025, 10, 10),
        EstaCerrada = false,
        EstacionSismologica = new EstacionSismologica
        {
            Nombre = "ES-Córdoba",
            Sismografo = new Sismografo { Identificador = "S-1001" }
        },
        Responsable = Sesion.UsuarioActual
    },
    new OrdenInspeccion
    {
        Id = "002",
        FechaFinalizacion = new DateTime(2025, 10, 20),
        EstaCerrada = false,
        EstacionSismologica = new EstacionSismologica
        {
            Nombre = "ES-Mendoza",
            Sismografo = new Sismografo { Identificador = "S-1002" }
        },
        Responsable = Sesion.UsuarioActual
    },
    new OrdenInspeccion
    {
        Id = "003",
        FechaFinalizacion = new DateTime(2025, 10, 15),
        EstaCerrada = false,
        EstacionSismologica = new EstacionSismologica
        {
            Nombre = "ES-Salta",
            Sismografo = new Sismografo { Identificador = "S-1003" }
        },
        Responsable = Sesion.UsuarioActual
    },
    new OrdenInspeccion
    {
        Id = "004",
        FechaFinalizacion = new DateTime(2025, 10, 18),
        EstaCerrada = false,
        EstacionSismologica = new EstacionSismologica
        {
            Nombre = "ES-San Luis",
            Sismografo = new Sismografo { Identificador = "S-1004" }
        },
        Responsable = Sesion.UsuarioActual
    },
    new OrdenInspeccion
    {
        Id = "005",
        FechaFinalizacion = new DateTime(2025, 10, 22),
        EstaCerrada = false,
        EstacionSismologica = new EstacionSismologica
        {
            Nombre = "ES-Chaco",
            Sismografo = new Sismografo { Identificador = "S-1005" }
        },
        Responsable = Sesion.UsuarioActual
    },
    new OrdenInspeccion
    {
        Id = "006",
        FechaFinalizacion = new DateTime(2025, 10, 25),
        EstaCerrada = false,
        EstacionSismologica = new EstacionSismologica
        {
            Nombre = "ES-Tierra del Fuego",
            Sismografo = new Sismografo { Identificador = "S-1006" }
        },
        Responsable = Sesion.UsuarioActual
    }
};

{
    // tus órdenes con Responsable = Sesion.UsuarioActual
};
            // 🔎 Filtrar solo las órdenes del responsable logueado
            ordenesPendientes = ordenesPendientes
        .Where(o => o.EsDeEmpleado(Sesion.UsuarioActual))
        .ToList();

            comboOrdenes.Items.Clear();
            comboOrdenes.Items.AddRange(
                ordenesPendientes.OrderByDescending(o => o.FechaFinalizacion).ToArray()
                    );
        }

        private void GuardarHistorial(OrdenInspeccion orden, List<MotivoTipo> motivos, string observacion)
        {
            string ruta = "historial_cierres.txt";
            string texto = $"=== ORDEN CERRADA ===\n" +
                           $"ID: {orden.Id}\n" +
                           $"Estación: {orden.EstacionSismologica.Nombre}\n" +
                           $"Sismógrafo: {orden.EstacionSismologica.Sismografo.Identificador}\n" +
                           $"Fecha de cierre: {orden.FechaCierre:dd/MM/yyyy HH:mm:ss}\n" +
                           $"Motivos:\n  - {string.Join("\n  - ", motivos)}\n" +
                           $"Observación: {observacion}\n" +
                           $"----------------------\n";

            File.AppendAllText(ruta, texto);
        }


        private void btnCerrarOrden_Click(object sender, EventArgs e)
        {
            if (comboOrdenes.SelectedItem is not OrdenInspeccion ordenSeleccionada)
            {
                MessageBox.Show("Debe seleccionar una orden.", "Error");
                return;
            }

            if (listMotivos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un motivo.", "Error");
                return;
            }

            var motivosSeleccionados = new List<MotivoTipo>();

            foreach (var motivo in listMotivos.CheckedItems)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Ingrese un comentario para el motivo: {motivo}",
                    "Comentario requerido",
                    ""
                );

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show($"Debe ingresar un comentario para el motivo '{motivo}'", "Comentario vacío");
                    return;
                }

                motivosSeleccionados.Add(new MotivoTipo
                {
                    Descripcion = motivo.ToString(),
                    Comentario = input
                });
            }

            string observacion = txtObservacion.Text.Trim();

            var confirmResult = MessageBox.Show(
                "¿Está seguro de que desea cerrar esta orden?\nEsta acción no se puede deshacer.",
                "Confirmar cierre",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Cierre cancelado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var gestor = new GestorCierreOrdInspeccion();

            gestor.CerrarOrden(
                ordenSeleccionada,
                motivosSeleccionados,
                observacion,
                Sesion.UsuarioActual.Nombre
            );

            List<Empleado> empleados = new()
    {
        new Empleado { Nombre = "Laura", Email = "laura@ccrs.com", Rol = "Reparacion" },
        new Empleado { Nombre = "Diego", Email = "diego@ccrs.com", Rol = "Logistica" },
        new Empleado { Nombre = "Mauro", Email = "mauro@ccrs.com", Rol = "Reparacion" }
    };

            gestor.NotificarPorMail(
                ordenSeleccionada.EstacionSismologica.Sismografo,
                motivosSeleccionados,
                Sesion.UsuarioActual.Nombre,
                empleados
            );

            GuardarHistorial(ordenSeleccionada, motivosSeleccionados, observacion);

            string resumen = $"✅ Orden cerrada:\n" +
                             $"- Estación: {ordenSeleccionada.EstacionSismologica.Nombre}\n" +
                             $"- Sismógrafo: {ordenSeleccionada.EstacionSismologica.Sismografo.Identificador}\n" +
                             $"- Motivos:\n  - {string.Join("\n  - ", motivosSeleccionados)}\n" +
                             $"- Observación general: {observacion}";

            MessageBox.Show(resumen, "Cierre de Orden");

            comboOrdenes.Items.Remove(ordenSeleccionada);
            txtObservacion.Clear();
            for (int i = 0; i < listMotivos.Items.Count; i++)
                listMotivos.SetItemChecked(i, false);
        }

        private void btnVerMails_Click(object sender, EventArgs e)
        {
            string ruta = "notificaciones_email.txt";

            if (!File.Exists(ruta))
            {
                MessageBox.Show("No hay notificaciones registradas.", "Sin registros");
                return;
            }

            string contenido = File.ReadAllText(ruta);
            MessageBox.Show(contenido, "Notificaciones enviadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVerFueraServicio_Click(object sender, EventArgs e)
        {
            var fueraDeServicio = ordenesPendientes
                .Where(o => o.EstacionSismologica.Sismografo.EsFueraDeServicio())
                .Select(o => $"- {o.EstacionSismologica.Nombre} ({o.EstacionSismologica.Sismografo.Identificador})")
                .ToList();

            if (fueraDeServicio.Count == 0)
            {
                MessageBox.Show("No hay sismógrafos fuera de servicio actualmente.", "Estado del sistema");
            }
            else
            {
                string lista = string.Join("\n", fueraDeServicio);
                MessageBox.Show($"Sismógrafos fuera de servicio:\n\n{lista}", "Fuera de Servicio");
            }
        }



    }
}

