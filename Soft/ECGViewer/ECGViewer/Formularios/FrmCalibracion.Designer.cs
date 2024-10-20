﻿namespace ECGViewer.Formularios
{
    partial class FrmCalibracion
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
            this.BtnAplicar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetECGValues = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudValorYMax = new System.Windows.Forms.NumericUpDown();
            this.nudValorYMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMin)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAplicar
            // 
            this.BtnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAplicar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAplicar.Location = new System.Drawing.Point(69, 225);
            this.BtnAplicar.Name = "BtnAplicar";
            this.BtnAplicar.Size = new System.Drawing.Size(103, 35);
            this.BtnAplicar.TabIndex = 2;
            this.BtnAplicar.Text = "&Aplicar";
            this.BtnAplicar.UseVisualStyleBackColor = true;
            this.BtnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(236, 225);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(103, 35);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetECGValues);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudValorYMax);
            this.groupBox1.Controls.Add(this.nudValorYMin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUnidad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 197);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mapeo de Valores";
            // 
            // btnResetECGValues
            // 
            this.btnResetECGValues.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetECGValues.Location = new System.Drawing.Point(87, 146);
            this.btnResetECGValues.Name = "btnResetECGValues";
            this.btnResetECGValues.Size = new System.Drawing.Size(207, 35);
            this.btnResetECGValues.TabIndex = 7;
            this.btnResetECGValues.Text = "Reset a Valores ECG Default";
            this.btnResetECGValues.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(169, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Unidad";
            // 
            // nudValorYMax
            // 
            this.nudValorYMax.DecimalPlaces = 2;
            this.nudValorYMax.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.nudValorYMax.Location = new System.Drawing.Point(235, 66);
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
            this.nudValorYMax.Size = new System.Drawing.Size(119, 25);
            this.nudValorYMax.TabIndex = 5;
            // 
            // nudValorYMin
            // 
            this.nudValorYMin.DecimalPlaces = 2;
            this.nudValorYMin.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.nudValorYMin.Location = new System.Drawing.Point(235, 24);
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
            this.nudValorYMin.Size = new System.Drawing.Size(120, 25);
            this.nudValorYMin.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor 1023 corresponde a ->";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor 0 corresponde a ->";
            // 
            // txtUnidad
            // 
            this.txtUnidad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtUnidad.Location = new System.Drawing.Point(235, 108);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(119, 25);
            this.txtUnidad.TabIndex = 0;
            // 
            // FrmCalibracion
            // 
            this.AcceptButton = this.BtnAplicar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(411, 281);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAplicar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCalibracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calibracion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorYMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAplicar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.NumericUpDown nudValorYMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudValorYMax;
        private System.Windows.Forms.Button btnResetECGValues;
    }
}