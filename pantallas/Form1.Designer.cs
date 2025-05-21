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
        private Button btnVerMails;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private Button btnVerHistorial;
        private Button btnVerFueraServicio;



        private void InitializeComponent()
        {
            comboOrdenes = new ComboBox();
            txtObservacion = new TextBox();
            listMotivos = new CheckedListBox();
            btnCerrarOrden = new Button();
            btnVerHistorial = new Button();
            btnVerMails = new Button();
            btnVerFueraServicio = new Button();

            lblComboTitulo = new Label();
            lblObservacion = new Label();
            lblMotivos = new Label();

            // 
            // comboOrdenes
            // 
            comboOrdenes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOrdenes.Location = new Point(20, 30);
            comboOrdenes.Size = new Size(300, 23);

            // 
            // lblComboTitulo
            // 
            lblComboTitulo.Text = "Seleccione una orden de inspección:";
            lblComboTitulo.Location = new Point(20, 10);
            lblComboTitulo.Size = new Size(300, 15);

            // 
            // lblObservacion
            // 
            lblObservacion.Text = "Observaciones:";
            lblObservacion.Location = new Point(20, 60);
            lblObservacion.Size = new Size(300, 15);

            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(20, 80);
            txtObservacion.Size = new Size(300, 80);
            txtObservacion.Multiline = true;

            // 
            // lblMotivos
            // 
            lblMotivos.Text = "Motivos de cierre:";
            lblMotivos.Location = new Point(20, 165);
            lblMotivos.Size = new Size(300, 15);

            // 
            // listMotivos
            // 
            listMotivos.Items.AddRange(new object[] {
        "Falla técnica", "Mantenimiento", "Sin energía", "Otro"
    });
            listMotivos.Location = new Point(20, 185);
            listMotivos.Size = new Size(300, 94);

            // 
            // btnCerrarOrden
            // 
            btnCerrarOrden.Text = "Cerrar Orden";
            btnCerrarOrden.Location = new Point(20, 290);
            btnCerrarOrden.Size = new Size(300, 30);
            btnCerrarOrden.Click += btnCerrarOrden_Click;

            // 
            // btnVerHistorial
            // 
            btnVerHistorial.Text = "Ver Historial";
            btnVerHistorial.Location = new Point(20, 330);
            btnVerHistorial.Size = new Size(300, 30);
            btnVerHistorial.Click += btnVerHistorial_Click;

            // 
            // btnVerMails
            // 
            btnVerMails.Text = "Ver mails enviados";
            btnVerMails.Location = new Point(20, 370);
            btnVerMails.Size = new Size(300, 30);
            btnVerMails.Click += btnVerMails_Click;

            // 
            // btnVerFueraServicio
            // 
            btnVerFueraServicio.Text = "Ver Sismógrafos Fuera de Servicio";
            btnVerFueraServicio.Location = new Point(20, 410);
            btnVerFueraServicio.Size = new Size(300, 30);
            btnVerFueraServicio.Click += btnVerFueraServicio_Click;

            // 
            // Form1
            // 
            ClientSize = new Size(360, 470);
            Controls.Add(comboOrdenes);
            Controls.Add(lblComboTitulo);
            Controls.Add(lblObservacion);
            Controls.Add(txtObservacion);
            Controls.Add(lblMotivos);
            Controls.Add(listMotivos);
            Controls.Add(btnCerrarOrden);
            Controls.Add(btnVerHistorial);
            Controls.Add(btnVerMails);
            Controls.Add(btnVerFueraServicio);
            Text = "Form1";
            Load += Form1_Load;
        }

    }
}



