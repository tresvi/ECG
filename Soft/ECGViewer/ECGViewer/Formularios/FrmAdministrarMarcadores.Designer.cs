namespace ECGViewer.Formularios
{
    partial class FrmAdministrarMarcadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lBMarcadores = new System.Windows.Forms.ListBox();
            this.btnBorrarMarcador = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lBMarcadores
            // 
            this.lBMarcadores.ColumnWidth = 100;
            this.lBMarcadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBMarcadores.FormattingEnabled = true;
            this.lBMarcadores.ItemHeight = 18;
            this.lBMarcadores.Location = new System.Drawing.Point(12, 12);
            this.lBMarcadores.Name = "lBMarcadores";
            this.lBMarcadores.Size = new System.Drawing.Size(639, 310);
            this.lBMarcadores.TabIndex = 1;
            this.lBMarcadores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lBMarcadores_KeyDown);
            // 
            // btnBorrarMarcador
            // 
            this.btnBorrarMarcador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarMarcador.Location = new System.Drawing.Point(261, 337);
            this.btnBorrarMarcador.Name = "btnBorrarMarcador";
            this.btnBorrarMarcador.Size = new System.Drawing.Size(119, 51);
            this.btnBorrarMarcador.TabIndex = 2;
            this.btnBorrarMarcador.Text = "&Borrar";
            this.btnBorrarMarcador.UseVisualStyleBackColor = true;
            this.btnBorrarMarcador.Click += new System.EventHandler(this.btnBorrarMarcador_Click);
            // 
            // FrmAdministrarMarcadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 400);
            this.Controls.Add(this.btnBorrarMarcador);
            this.Controls.Add(this.lBMarcadores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdministrarMarcadores";
            this.Text = "Administrar Marcadores";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lBMarcadores;
        private System.Windows.Forms.Button btnBorrarMarcador;
    }
}