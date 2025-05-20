using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using System.Drawing;
using System.Windows.Forms;

namespace CierreOrdenApp
{
    public partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox comboOrdenes;
        private TextBox txtObservacion;
        private CheckedListBox listMotivos;
        private Button btnCerrarOrden;
        private Label lblComboTitulo;
        private Label lblObservacion;
        private Label lblMotivos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Load += Form1_Load;

            lblComboTitulo = new Label();
            lblComboTitulo.Text = "Seleccione una orden de inspección:";
            lblComboTitulo.Location = new Point(20, 0);
            lblComboTitulo.Size = new Size(300, 20);

            lblObservacion = new Label();
            lblObservacion.Text = "Observaciones:";
            lblObservacion.Location = new Point(20, 40);
            lblObservacion.Size = new Size(300, 15);

            lblMotivos = new Label();
            lblMotivos.Text = "Motivos de cierre:";
            lblMotivos.Location = new Point(20, 140);
            lblMotivos.Size = new Size(300, 15);

            comboOrdenes = new ComboBox();
            comboOrdenes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOrdenes.Location = new Point(20, 20);
            comboOrdenes.Size = new Size(300, 23);

            txtObservacion = new TextBox();
            txtObservacion.Multiline = true;
            txtObservacion.Location = new Point(20, 60);
            txtObservacion.Size = new Size(300, 80);

            listMotivos = new CheckedListBox();
            listMotivos.Items.AddRange(new object[] { "Falla técnica", "Mantenimiento", "Sin energía", "Otro" });
            listMotivos.Location = new Point(20, 160);
            listMotivos.Size = new Size(300, 94);

            btnCerrarOrden = new Button();
            btnCerrarOrden.Location = new Point(20, 280);
            btnCerrarOrden.Size = new Size(300, 30);
            btnCerrarOrden.Text = "Cerrar Orden";
            btnCerrarOrden.Click += btnCerrarOrden_Click;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(lblComboTitulo);
            this.Controls.Add(lblObservacion);
            this.Controls.Add(lblMotivos);
            this.Controls.Add(comboOrdenes);
            this.Controls.Add(txtObservacion);
            this.Controls.Add(listMotivos);
            this.Controls.Add(btnCerrarOrden);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}



