namespace ECGViewer.Formularios
{
    partial class FrmControlesFiltroInteractivo
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
            this.tbFCorteInferior = new System.Windows.Forms.TrackBar();
            this.lblFCorteInferior = new System.Windows.Forms.Label();
            this.tbFCorteSuperior = new System.Windows.Forms.TrackBar();
            this.lblFCorteSuperior = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkTransparencia = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbFCorteInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFCorteSuperior)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFCorteInferior
            // 
            this.tbFCorteInferior.Location = new System.Drawing.Point(64, 80);
            this.tbFCorteInferior.Maximum = 200;
            this.tbFCorteInferior.Name = "tbFCorteInferior";
            this.tbFCorteInferior.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbFCorteInferior.RightToLeftLayout = true;
            this.tbFCorteInferior.Size = new System.Drawing.Size(45, 478);
            this.tbFCorteInferior.TabIndex = 1;
            this.tbFCorteInferior.TickFrequency = 2;
            this.tbFCorteInferior.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbFCorteInferior.Value = 200;
            this.tbFCorteInferior.ValueChanged += new System.EventHandler(this.tbFCorteInferior_ValueChanged);
            // 
            // lblFCorteInferior
            // 
            this.lblFCorteInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFCorteInferior.Font = new System.Drawing.Font("Arial", 13F);
            this.lblFCorteInferior.Location = new System.Drawing.Point(21, 44);
            this.lblFCorteInferior.Name = "lblFCorteInferior";
            this.lblFCorteInferior.Size = new System.Drawing.Size(106, 24);
            this.lblFCorteInferior.TabIndex = 2;
            this.lblFCorteInferior.Text = "0.0 Hz";
            this.lblFCorteInferior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFCorteSuperior
            // 
            this.tbFCorteSuperior.Location = new System.Drawing.Point(191, 80);
            this.tbFCorteSuperior.Maximum = 200;
            this.tbFCorteSuperior.Name = "tbFCorteSuperior";
            this.tbFCorteSuperior.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbFCorteSuperior.RightToLeftLayout = true;
            this.tbFCorteSuperior.Size = new System.Drawing.Size(45, 478);
            this.tbFCorteSuperior.TabIndex = 3;
            this.tbFCorteSuperior.TickFrequency = 2;
            this.tbFCorteSuperior.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbFCorteSuperior.ValueChanged += new System.EventHandler(this.tbFCorteSuperior_ValueChanged);
            // 
            // lblFCorteSuperior
            // 
            this.lblFCorteSuperior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFCorteSuperior.Font = new System.Drawing.Font("Arial", 13F);
            this.lblFCorteSuperior.Location = new System.Drawing.Point(149, 45);
            this.lblFCorteSuperior.Name = "lblFCorteSuperior";
            this.lblFCorteSuperior.Size = new System.Drawing.Size(106, 24);
            this.lblFCorteSuperior.TabIndex = 4;
            this.lblFCorteSuperior.Text = "100.0 Hz";
            this.lblFCorteSuperior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.Location = new System.Drawing.Point(38, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "0-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F);
            this.label2.Location = new System.Drawing.Point(18, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "100-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F);
            this.label3.Location = new System.Drawing.Point(26, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "50-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F);
            this.label4.Location = new System.Drawing.Point(155, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "50-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F);
            this.label5.Location = new System.Drawing.Point(146, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "100-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F);
            this.label6.Location = new System.Drawing.Point(166, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "0-";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.Location = new System.Drawing.Point(21, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "F. Corte Inf.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Arial", 12F);
            this.label8.Location = new System.Drawing.Point(149, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "F. Corte Sup.";
            // 
            // chkTransparencia
            // 
            this.chkTransparencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTransparencia.AutoSize = true;
            this.chkTransparencia.Font = new System.Drawing.Font("Arial", 12F);
            this.chkTransparencia.Location = new System.Drawing.Point(143, 595);
            this.chkTransparencia.Name = "chkTransparencia";
            this.chkTransparencia.Size = new System.Drawing.Size(126, 22);
            this.chkTransparencia.TabIndex = 13;
            this.chkTransparencia.Text = "Transparencia";
            this.chkTransparencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransparencia.UseVisualStyleBackColor = true;
            this.chkTransparencia.CheckedChanged += new System.EventHandler(this.chkTransparencia_CheckedChanged);
            // 
            // FrmControlesFiltroInteractivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(271, 617);
            this.Controls.Add(this.chkTransparencia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFCorteSuperior);
            this.Controls.Add(this.tbFCorteSuperior);
            this.Controls.Add(this.lblFCorteInferior);
            this.Controls.Add(this.tbFCorteInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControlesFiltroInteractivo";
            this.Text = "Controles Filtro Pasa Banda";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmControlesFiltroInteractivo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbFCorteInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFCorteSuperior)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar tbFCorteInferior;
        private System.Windows.Forms.Label lblFCorteInferior;
        private System.Windows.Forms.TrackBar tbFCorteSuperior;
        private System.Windows.Forms.Label lblFCorteSuperior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkTransparencia;
    }
}