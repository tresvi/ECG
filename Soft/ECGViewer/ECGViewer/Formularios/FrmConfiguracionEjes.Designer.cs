namespace ECGViewer.Formularios
{
    partial class FrmConfiguracionEjes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudYMax = new System.Windows.Forms.NumericUpDown();
            this.nudYMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.chkEscalaAutomatica = new System.Windows.Forms.CheckBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYMin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudYMax);
            this.groupBox1.Controls.Add(this.nudYMin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUnidad);
            this.groupBox1.Controls.Add(this.chkEscalaAutomatica);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 160);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eje Y";
            // 
            // nudYMax
            // 
            this.nudYMax.DecimalPlaces = 3;
            this.nudYMax.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudYMax.Location = new System.Drawing.Point(230, 109);
            this.nudYMax.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYMax.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudYMax.Name = "nudYMax";
            this.nudYMax.Size = new System.Drawing.Size(115, 29);
            this.nudYMax.TabIndex = 32;
            this.nudYMax.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudYMin
            // 
            this.nudYMin.DecimalPlaces = 3;
            this.nudYMin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudYMin.Location = new System.Drawing.Point(48, 109);
            this.nudYMin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYMin.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudYMin.Name = "nudYMin";
            this.nudYMin.Size = new System.Drawing.Size(115, 29);
            this.nudYMin.TabIndex = 31;
            this.nudYMin.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Min";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Unidad";
            // 
            // txtUnidad
            // 
            this.txtUnidad.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnidad.Location = new System.Drawing.Point(75, 29);
            this.txtUnidad.MaxLength = 10;
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(86, 29);
            this.txtUnidad.TabIndex = 25;
            this.txtUnidad.Text = "mV";
            // 
            // chkEscalaAutomatica
            // 
            this.chkEscalaAutomatica.AutoSize = true;
            this.chkEscalaAutomatica.Checked = true;
            this.chkEscalaAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEscalaAutomatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEscalaAutomatica.Location = new System.Drawing.Point(6, 74);
            this.chkEscalaAutomatica.Name = "chkEscalaAutomatica";
            this.chkEscalaAutomatica.Size = new System.Drawing.Size(167, 22);
            this.chkEscalaAutomatica.TabIndex = 24;
            this.chkEscalaAutomatica.Text = "Escala Automatica";
            this.chkEscalaAutomatica.UseVisualStyleBackColor = true;
            this.chkEscalaAutomatica.CheckedChanged += new System.EventHandler(this.chkEscalaAutomatica_CheckedChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(221, 192);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 37);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "&Salir>>";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAplicar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(57, 192);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(103, 37);
            this.btnAplicar.TabIndex = 25;
            this.btnAplicar.Text = "&Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // FrmConfiguracionEjes
            // 
            this.AcceptButton = this.btnAplicar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(381, 260);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmConfiguracionEjes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuracion Ejes";
            this.Load += new System.EventHandler(this.FrmConfiguracionEjes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.CheckBox chkEscalaAutomatica;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.NumericUpDown nudYMax;
        private System.Windows.Forms.NumericUpDown nudYMin;
    }
}