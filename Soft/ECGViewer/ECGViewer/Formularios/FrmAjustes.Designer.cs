namespace ECGViewer.Formularios
{
    partial class FrmAjustes
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
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCalibBitsMax = new System.Windows.Forms.NumericUpDown();
            this.nudCalibBitsMin = new System.Windows.Forms.NumericUpDown();
            this.lblZero = new System.Windows.Forms.Label();
            this.lblSpan = new System.Windows.Forms.Label();
            this.btnResetECGValues = new System.Windows.Forms.Button();
            this.nudCalibValorYMax = new System.Windows.Forms.NumericUpDown();
            this.nudCalibValorYMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMuestrasPorGrafico = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.chkMuestrasADC = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibBitsMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibBitsMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibValorYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibValorYMin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestrasPorGrafico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAplicar
            // 
            this.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAplicar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(69, 490);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(103, 37);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "A&plicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(226, 490);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 37);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Salir>>";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudCalibBitsMax);
            this.groupBox1.Controls.Add(this.nudCalibBitsMin);
            this.groupBox1.Controls.Add(this.lblZero);
            this.groupBox1.Controls.Add(this.lblSpan);
            this.groupBox1.Controls.Add(this.btnResetECGValues);
            this.groupBox1.Controls.Add(this.nudCalibValorYMax);
            this.groupBox1.Controls.Add(this.nudCalibValorYMin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 244);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibración - Mapeo de Valores ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "-------->";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(127, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "-------->";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(221, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mapea con valor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(221, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mapea con valor";
            // 
            // nudCalibBitsMax
            // 
            this.nudCalibBitsMax.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalibBitsMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudCalibBitsMax.Location = new System.Drawing.Point(15, 108);
            this.nudCalibBitsMax.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudCalibBitsMax.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudCalibBitsMax.Name = "nudCalibBitsMax";
            this.nudCalibBitsMax.Size = new System.Drawing.Size(103, 26);
            this.nudCalibBitsMax.TabIndex = 11;
            this.nudCalibBitsMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCalibBitsMax.Value = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.nudCalibBitsMax.ValueChanged += new System.EventHandler(this.nudCalibBitsMax_ValueChanged);
            // 
            // nudCalibBitsMin
            // 
            this.nudCalibBitsMin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalibBitsMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudCalibBitsMin.Location = new System.Drawing.Point(15, 51);
            this.nudCalibBitsMin.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudCalibBitsMin.Name = "nudCalibBitsMin";
            this.nudCalibBitsMin.Size = new System.Drawing.Size(103, 26);
            this.nudCalibBitsMin.TabIndex = 10;
            this.nudCalibBitsMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCalibBitsMin.ValueChanged += new System.EventHandler(this.nudCalibBitsMin_ValueChanged);
            // 
            // lblZero
            // 
            this.lblZero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZero.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero.Location = new System.Drawing.Point(15, 160);
            this.lblZero.Name = "lblZero";
            this.lblZero.Size = new System.Drawing.Size(161, 20);
            this.lblZero.TabIndex = 9;
            this.lblZero.Text = "ZERO: XX";
            // 
            // lblSpan
            // 
            this.lblSpan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpan.Location = new System.Drawing.Point(193, 159);
            this.lblSpan.Name = "lblSpan";
            this.lblSpan.Size = new System.Drawing.Size(161, 20);
            this.lblSpan.TabIndex = 8;
            this.lblSpan.Text = "SPAN: XX";
            // 
            // btnResetECGValues
            // 
            this.btnResetECGValues.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetECGValues.Location = new System.Drawing.Point(86, 195);
            this.btnResetECGValues.Name = "btnResetECGValues";
            this.btnResetECGValues.Size = new System.Drawing.Size(207, 35);
            this.btnResetECGValues.TabIndex = 7;
            this.btnResetECGValues.Text = "Reset a Valores ECG Default";
            this.btnResetECGValues.UseVisualStyleBackColor = true;
            this.btnResetECGValues.Click += new System.EventHandler(this.btnResetECGValues_Click);
            // 
            // nudCalibValorYMax
            // 
            this.nudCalibValorYMax.DecimalPlaces = 3;
            this.nudCalibValorYMax.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalibValorYMax.Location = new System.Drawing.Point(224, 108);
            this.nudCalibValorYMax.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCalibValorYMax.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudCalibValorYMax.Name = "nudCalibValorYMax";
            this.nudCalibValorYMax.Size = new System.Drawing.Size(130, 26);
            this.nudCalibValorYMax.TabIndex = 5;
            this.nudCalibValorYMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCalibValorYMax.ValueChanged += new System.EventHandler(this.nudValorYMax_ValueChanged);
            // 
            // nudCalibValorYMin
            // 
            this.nudCalibValorYMin.DecimalPlaces = 3;
            this.nudCalibValorYMin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalibValorYMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudCalibValorYMin.Location = new System.Drawing.Point(224, 51);
            this.nudCalibValorYMin.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCalibValorYMin.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudCalibValorYMin.Name = "nudCalibValorYMin";
            this.nudCalibValorYMin.Size = new System.Drawing.Size(130, 26);
            this.nudCalibValorYMin.TabIndex = 4;
            this.nudCalibValorYMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCalibValorYMin.ValueChanged += new System.EventHandler(this.nudValorYMin_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor bits Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor bits Min";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nudMuestrasPorGrafico);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 129);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gráfico";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(22, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 62);
            this.label5.TabIndex = 10;
            this.label5.Text = "(Para equipos con bajas prestaciones se recomienda un valor mas bajos. Valor esta" +
    "ndar recomendado: 4000)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nro Muestras por pantalla";
            // 
            // nudMuestrasPorGrafico
            // 
            this.nudMuestrasPorGrafico.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMuestrasPorGrafico.Location = new System.Drawing.Point(243, 26);
            this.nudMuestrasPorGrafico.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMuestrasPorGrafico.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMuestrasPorGrafico.Name = "nudMuestrasPorGrafico";
            this.nudMuestrasPorGrafico.Size = new System.Drawing.Size(95, 26);
            this.nudMuestrasPorGrafico.TabIndex = 8;
            this.nudMuestrasPorGrafico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMuestrasPorGrafico.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Unidad";
            // 
            // txtUnidad
            // 
            this.txtUnidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnidad.Location = new System.Drawing.Point(82, 444);
            this.txtUnidad.MaxLength = 10;
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(86, 26);
            this.txtUnidad.TabIndex = 18;
            this.txtUnidad.Text = "mV";
            // 
            // chkMuestrasADC
            // 
            this.chkMuestrasADC.AutoSize = true;
            this.chkMuestrasADC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMuestrasADC.Location = new System.Drawing.Point(12, 156);
            this.chkMuestrasADC.Name = "chkMuestrasADC";
            this.chkMuestrasADC.Size = new System.Drawing.Size(256, 22);
            this.chkMuestrasADC.TabIndex = 16;
            this.chkMuestrasADC.Text = "Usar valores en crudo de ADC";
            this.chkMuestrasADC.UseVisualStyleBackColor = true;
            this.chkMuestrasADC.CheckedChanged += new System.EventHandler(this.chkMuestrasADC_CheckedChanged);
            // 
            // FrmAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(397, 546);
            this.ControlBox = false;
            this.Controls.Add(this.chkMuestrasADC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUnidad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAjustes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajustes para captura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibBitsMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibBitsMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibValorYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibValorYMin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestrasPorGrafico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudCalibValorYMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCalibValorYMax;
        private System.Windows.Forms.Button btnResetECGValues;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMuestrasPorGrafico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblZero;
        private System.Windows.Forms.Label lblSpan;
        private System.Windows.Forms.NumericUpDown nudCalibBitsMax;
        private System.Windows.Forms.NumericUpDown nudCalibBitsMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.CheckBox chkMuestrasADC;
    }
}