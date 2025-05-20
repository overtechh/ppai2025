// ✔️ Pone esto al principio del archivo:
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CierreOrdenApp
{
    public partial class Form1 : Form
    {
        private List<OrdenInspeccion> ordenesPendientes = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var todasLasOrdenes = new List<OrdenInspeccion>
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
                    }
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
                    }
                },
                new OrdenInspeccion
                {
                    Id = "003",
                    FechaFinalizacion = new DateTime(2025, 10, 15),
                    EstaCerrada = false,
                    EstacionSismologica = new EstacionSismologica
                    {
                        Nombre = "ES-Jujuy",
                        Sismografo = new Sismografo { Identificador = "S-1003" }
                    }
                }
            };

            var gestor = new GestorCierreOrdInspeccion();
            ordenesPendientes = gestor.BuscarOrdenesPendientes(todasLasOrdenes);

            comboOrdenes.Items.Clear();
            comboOrdenes.Items.AddRange(ordenesPendientes.ToArray());
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

            string observacion = txtObservacion.Text.Trim();
            var motivos = listMotivos.CheckedItems.Cast<string>().ToList();

            ordenSeleccionada.EstaCerrada = true;

            string resumen = $"✅ Orden cerrada:\n" +
                             $"- Estación: {ordenSeleccionada.EstacionSismologica.Nombre}\n" +
                             $"- Sismógrafo: {ordenSeleccionada.EstacionSismologica.Sismografo.Identificador}\n" +
                             $"- Motivos: {string.Join(", ", motivos)}\n" +
                             $"- Observación: {observacion}";

            MessageBox.Show(resumen, "Cierre de Orden");

            comboOrdenes.Items.Remove(ordenSeleccionada);
            txtObservacion.Clear();
            for (int i = 0; i < listMotivos.Items.Count; i++)
                listMotivos.SetItemChecked(i, false);
        }
    }
}

