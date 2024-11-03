namespace ECGViewer.Formularios
{
    partial class FrmExportarATablaC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExportarATablaC));
            this.gpbSaltoLinea = new System.Windows.Forms.GroupBox();
            this.cmbSaltoLinea = new System.Windows.Forms.ComboBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBinario = new System.Windows.Forms.RadioButton();
            this.rbEstiloAssembler = new System.Windows.Forms.RadioButton();
            this.rbEstiloC = new System.Windows.Forms.RadioButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbEscaladoBits = new System.Windows.Forms.GroupBox();
            this.cmbBitsEscalado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbSaltoLinea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbEscaladoBits.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbSaltoLinea
            // 
            this.gpbSaltoLinea.Controls.Add(this.cmbSaltoLinea);
            this.gpbSaltoLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F);
            this.gpbSaltoLinea.Location = new System.Drawing.Point(10, 137);
            this.gpbSaltoLinea.Margin = new System.Windows.Forms.Padding(1);
            this.gpbSaltoLinea.Name = "gpbSaltoLinea";
            this.gpbSaltoLinea.Padding = new System.Windows.Forms.Padding(1);
            this.gpbSaltoLinea.Size = new System.Drawing.Size(205, 69);
            this.gpbSaltoLinea.TabIndex = 21;
            this.gpbSaltoLinea.TabStop = false;
            this.gpbSaltoLinea.Text = "Agregar salto de línea cada:";
            // 
            // cmbSaltoLinea
            // 
            this.cmbSaltoLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSaltoLinea.FormattingEnabled = true;
            this.cmbSaltoLinea.Items.AddRange(new object[] {
            "Sin salto",
            "10 valores",
            "20 valores",
            "30 valores",
            "40 valores",
            "50 valores",
            "60 valores",
            "70 valores",
            "80 valores",
            "90 valores",
            "100 valores"});
            this.cmbSaltoLinea.Location = new System.Drawing.Point(7, 29);
            this.cmbSaltoLinea.Margin = new System.Windows.Forms.Padding(1);
            this.cmbSaltoLinea.Name = "cmbSaltoLinea";
            this.cmbSaltoLinea.Size = new System.Drawing.Size(193, 24);
            this.cmbSaltoLinea.TabIndex = 17;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(382, 298);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 34);
            this.btnExportar.TabIndex = 20;
            this.btnExportar.Text = "Exportar...";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbBinario);
            this.groupBox1.Controls.Add(this.rbEstiloAssembler);
            this.groupBox1.Controls.Add(this.rbEstiloC);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(205, 125);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Estilo de Tabla";
            // 
            // rbBinario
            // 
            this.rbBinario.AutoSize = true;
            this.rbBinario.Enabled = false;
            this.rbBinario.Font = new System.Drawing.Font("Arial", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBinario.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.rbBinario.Location = new System.Drawing.Point(7, 87);
            this.rbBinario.Margin = new System.Windows.Forms.Padding(1);
            this.rbBinario.Name = "rbBinario";
            this.rbBinario.Size = new System.Drawing.Size(180, 22);
            this.rbBinario.TabIndex = 4;
            this.rbBinario.TabStop = true;
            this.rbBinario.Text = " Archivo Binario 8 bits";
            this.rbBinario.UseVisualStyleBackColor = true;
            // 
            // rbEstiloAssembler
            // 
            this.rbEstiloAssembler.AutoSize = true;
            this.rbEstiloAssembler.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEstiloAssembler.Location = new System.Drawing.Point(7, 57);
            this.rbEstiloAssembler.Margin = new System.Windows.Forms.Padding(1);
            this.rbEstiloAssembler.Name = "rbEstiloAssembler";
            this.rbEstiloAssembler.Size = new System.Drawing.Size(143, 22);
            this.rbEstiloAssembler.TabIndex = 3;
            this.rbEstiloAssembler.TabStop = true;
            this.rbEstiloAssembler.Text = "Estilo Assembler";
            this.rbEstiloAssembler.UseVisualStyleBackColor = true;
            // 
            // rbEstiloC
            // 
            this.rbEstiloC.AutoSize = true;
            this.rbEstiloC.Checked = true;
            this.rbEstiloC.Font = new System.Drawing.Font("Arial", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEstiloC.Location = new System.Drawing.Point(7, 30);
            this.rbEstiloC.Margin = new System.Windows.Forms.Padding(1);
            this.rbEstiloC.Name = "rbEstiloC";
            this.rbEstiloC.Size = new System.Drawing.Size(114, 22);
            this.rbEstiloC.TabIndex = 2;
            this.rbEstiloC.TabStop = true;
            this.rbEstiloC.Text = "Estilo C/C++";
            this.rbEstiloC.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ECGViewer.Properties.Resources.PWM_Picture;
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 249);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(229, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 276);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Esquema/Programa ejemplo";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(338, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(318, 249);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // gbEscaladoBits
            // 
            this.gbEscaladoBits.Controls.Add(this.label1);
            this.gbEscaladoBits.Controls.Add(this.cmbBitsEscalado);
            this.gbEscaladoBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F);
            this.gbEscaladoBits.Location = new System.Drawing.Point(10, 213);
            this.gbEscaladoBits.Margin = new System.Windows.Forms.Padding(1);
            this.gbEscaladoBits.Name = "gbEscaladoBits";
            this.gbEscaladoBits.Padding = new System.Windows.Forms.Padding(1);
            this.gbEscaladoBits.Size = new System.Drawing.Size(205, 69);
            this.gbEscaladoBits.TabIndex = 25;
            this.gbEscaladoBits.TabStop = false;
            this.gbEscaladoBits.Text = "Escalar para:";
            // 
            // cmbBitsEscalado
            // 
            this.cmbBitsEscalado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitsEscalado.FormattingEnabled = true;
            this.cmbBitsEscalado.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "16",
            "24",
            "32"});
            this.cmbBitsEscalado.Location = new System.Drawing.Point(7, 29);
            this.cmbBitsEscalado.Margin = new System.Windows.Forms.Padding(1);
            this.cmbBitsEscalado.Name = "cmbBitsEscalado";
            this.cmbBitsEscalado.Size = new System.Drawing.Size(114, 24);
            this.cmbBitsEscalado.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(141, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Bits";
            // 
            // FrmExportarATablaC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 351);
            this.Controls.Add(this.gbEscaladoBits);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbSaltoLinea);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExportarATablaC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exportar a tabla";
            this.gpbSaltoLinea.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbEscaladoBits.ResumeLayout(false);
            this.gbEscaladoBits.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSaltoLinea;
        private System.Windows.Forms.ComboBox cmbSaltoLinea;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbBinario;
        private System.Windows.Forms.RadioButton rbEstiloAssembler;
        private System.Windows.Forms.RadioButton rbEstiloC;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbEscaladoBits;
        private System.Windows.Forms.ComboBox cmbBitsEscalado;
        private System.Windows.Forms.Label label1;
    }
}