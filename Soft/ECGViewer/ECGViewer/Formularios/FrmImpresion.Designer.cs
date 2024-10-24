namespace ECGViewer.Formularios
{
    partial class FrmImpresion
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
            this.gbSecciones = new System.Windows.Forms.GroupBox();
            this.rbTriple = new System.Windows.Forms.RadioButton();
            this.rbDoble = new System.Windows.Forms.RadioButton();
            this.rbSimple = new System.Windows.Forms.RadioButton();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.gbSecciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSecciones
            // 
            this.gbSecciones.Controls.Add(this.rbTriple);
            this.gbSecciones.Controls.Add(this.rbDoble);
            this.gbSecciones.Controls.Add(this.rbSimple);
            this.gbSecciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSecciones.Location = new System.Drawing.Point(14, 11);
            this.gbSecciones.Name = "gbSecciones";
            this.gbSecciones.Size = new System.Drawing.Size(213, 158);
            this.gbSecciones.TabIndex = 0;
            this.gbSecciones.TabStop = false;
            this.gbSecciones.Text = "Modo de Impresion";
            // 
            // rbTriple
            // 
            this.rbTriple.AutoSize = true;
            this.rbTriple.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTriple.Location = new System.Drawing.Point(67, 111);
            this.rbTriple.Name = "rbTriple";
            this.rbTriple.Size = new System.Drawing.Size(87, 22);
            this.rbTriple.TabIndex = 5;
            this.rbTriple.Text = "3 partes";
            this.rbTriple.UseVisualStyleBackColor = true;
            // 
            // rbDoble
            // 
            this.rbDoble.AutoSize = true;
            this.rbDoble.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDoble.Location = new System.Drawing.Point(67, 74);
            this.rbDoble.Name = "rbDoble";
            this.rbDoble.Size = new System.Drawing.Size(87, 22);
            this.rbDoble.TabIndex = 4;
            this.rbDoble.Text = "2 partes";
            this.rbDoble.UseVisualStyleBackColor = true;
            // 
            // rbSimple
            // 
            this.rbSimple.AutoSize = true;
            this.rbSimple.Checked = true;
            this.rbSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSimple.Location = new System.Drawing.Point(67, 38);
            this.rbSimple.Name = "rbSimple";
            this.rbSimple.Size = new System.Drawing.Size(77, 22);
            this.rbSimple.TabIndex = 3;
            this.rbSimple.TabStop = true;
            this.rbSimple.Text = "Simple";
            this.rbSimple.UseVisualStyleBackColor = true;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(67, 179);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(103, 35);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "&Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FrmImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 224);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.gbSecciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmImpresion";
            this.Text = "Impresion";
            this.gbSecciones.ResumeLayout(false);
            this.gbSecciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSecciones;
        private System.Windows.Forms.RadioButton rbTriple;
        private System.Windows.Forms.RadioButton rbDoble;
        private System.Windows.Forms.RadioButton rbSimple;
        private System.Windows.Forms.Button BtnAceptar;
    }
}