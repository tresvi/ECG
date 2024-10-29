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
            this.btnResetECGValues = new System.Windows.Forms.Button();
            this.nudValorYMax = new System.Windows.Forms.NumericUpDown();
            this.nudValorYMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMuestrasPorGrafico = new System.Windows.Forms.NumericUpDown();
            this.lblSpan = new System.Windows.Forms.Label();
            this.lblZero = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestrasPorGrafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAplicar
            // 
            this.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAplicar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(149, 485);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(103, 35);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "A&plicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(274, 485);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUnidad);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.lblZero);
            this.groupBox1.Controls.Add(this.lblSpan);
            this.groupBox1.Controls.Add(this.btnResetECGValues);
            this.groupBox1.Controls.Add(this.nudValorYMax);
            this.groupBox1.Controls.Add(this.nudValorYMin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 293);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibración - Mapeo de Valores";
            // 
            // btnResetECGValues
            // 
            this.btnResetECGValues.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetECGValues.Location = new System.Drawing.Point(86, 252);
            this.btnResetECGValues.Name = "btnResetECGValues";
            this.btnResetECGValues.Size = new System.Drawing.Size(207, 35);
            this.btnResetECGValues.TabIndex = 7;
            this.btnResetECGValues.Text = "Reset a Valores ECG Default";
            this.btnResetECGValues.UseVisualStyleBackColor = true;
            // 
            // nudValorYMax
            // 
            this.nudValorYMax.DecimalPlaces = 3;
            this.nudValorYMax.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudValorYMax.Location = new System.Drawing.Point(224, 114);
            this.nudValorYMax.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudValorYMax.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudValorYMax.Name = "nudValorYMax";
            this.nudValorYMax.Size = new System.Drawing.Size(130, 26);
            this.nudValorYMax.TabIndex = 5;
            this.nudValorYMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudValorYMax.ValueChanged += new System.EventHandler(this.nudValorYMax_ValueChanged);
            // 
            // nudValorYMin
            // 
            this.nudValorYMin.DecimalPlaces = 3;
            this.nudValorYMin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudValorYMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudValorYMin.Location = new System.Drawing.Point(224, 51);
            this.nudValorYMin.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudValorYMin.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudValorYMin.Name = "nudValorYMin";
            this.nudValorYMin.Size = new System.Drawing.Size(130, 26);
            this.nudValorYMin.TabIndex = 4;
            this.nudValorYMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudValorYMin.ValueChanged += new System.EventHandler(this.nudValorYMin_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 93);
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
            this.groupBox2.Size = new System.Drawing.Size(371, 144);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gráfico";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(22, 59);
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
            // lblSpan
            // 
            this.lblSpan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpan.Location = new System.Drawing.Point(193, 170);
            this.lblSpan.Name = "lblSpan";
            this.lblSpan.Size = new System.Drawing.Size(161, 20);
            this.lblSpan.TabIndex = 8;
            this.lblSpan.Text = "SPAN: XX";
            // 
            // lblZero
            // 
            this.lblZero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZero.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero.Location = new System.Drawing.Point(11, 170);
            this.lblZero.Name = "lblZero";
            this.lblZero.Size = new System.Drawing.Size(161, 20);
            this.lblZero.TabIndex = 9;
            this.lblZero.Text = "ZERO: XX";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(27, 485);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(103, 35);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(15, 51);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 26);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown2.Location = new System.Drawing.Point(15, 114);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(103, 26);
            this.numericUpDown2.TabIndex = 11;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = new decimal(new int[] {
            1023,
            0,
            0,
            0});
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(221, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mapea con valor";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "-------->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Unidad";
            // 
            // txtUnidad
            // 
            this.txtUnidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnidad.Location = new System.Drawing.Point(86, 210);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(86, 26);
            this.txtUnidad.TabIndex = 16;
            this.txtUnidad.Text = "mV";
            // 
            // FrmAjustes
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(397, 546);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAjustes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajustes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestrasPorGrafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudValorYMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudValorYMax;
        private System.Windows.Forms.Button btnResetECGValues;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMuestrasPorGrafico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblZero;
        private System.Windows.Forms.Label lblSpan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.Label label9;
    }
}