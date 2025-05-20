namespace CierreOrdenApp
{
    partial class FormInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private Label lblTitulo;
        private Button btnCerrarOrden;

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.btnCerrarOrden = new Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.Location = new Point(90, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(150, 32);
            this.lblTitulo.Text = "Red Sísmica";
            // 
            // btnCerrarOrden
            // 
            this.btnCerrarOrden.Location = new Point(70, 90);
            this.btnCerrarOrden.Name = "btnCerrarOrden";
            this.btnCerrarOrden.Size = new Size(200, 40);
            this.btnCerrarOrden.Text = "Cerrar Orden de Inspección";
            this.btnCerrarOrden.UseVisualStyleBackColor = true;
            this.btnCerrarOrden.Click += new EventHandler(this.btnCerrarOrden_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(340, 180);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrarOrden);
            this.Name = "FormInicio";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
