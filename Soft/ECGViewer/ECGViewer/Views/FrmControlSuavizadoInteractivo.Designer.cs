namespace ECGViewer.Views
{
    partial class FrmControlSuavizadoInteractivo
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
            this.lblSuavizar = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSuavizado = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.chkTransparencia = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbSuavizado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSuavizar
            // 
            this.lblSuavizar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSuavizar.Font = new System.Drawing.Font("Arial", 13F);
            this.lblSuavizar.Location = new System.Drawing.Point(39, 19);
            this.lblSuavizar.Name = "lblSuavizar";
            this.lblSuavizar.Size = new System.Drawing.Size(59, 24);
            this.lblSuavizar.TabIndex = 33;
            this.lblSuavizar.Text = "0";
            this.lblSuavizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14F);
            this.label9.Location = new System.Drawing.Point(7, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 22);
            this.label9.TabIndex = 32;
            this.label9.Text = "40-";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14F);
            this.label10.Location = new System.Drawing.Point(9, 504);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 22);
            this.label10.TabIndex = 31;
            this.label10.Text = "80-";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbSuavizado
            // 
            this.tbSuavizado.LargeChange = 1;
            this.tbSuavizado.Location = new System.Drawing.Point(48, 53);
            this.tbSuavizado.Maximum = 80;
            this.tbSuavizado.Name = "tbSuavizado";
            this.tbSuavizado.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbSuavizado.RightToLeftLayout = true;
            this.tbSuavizado.Size = new System.Drawing.Size(45, 478);
            this.tbSuavizado.TabIndex = 29;
            this.tbSuavizado.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbSuavizado.Value = 80;
            this.tbSuavizado.ValueChanged += new System.EventHandler(this.tbSuavizado_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14F);
            this.label11.Location = new System.Drawing.Point(19, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 22);
            this.label11.TabIndex = 30;
            this.label11.Text = "0-";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkTransparencia
            // 
            this.chkTransparencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTransparencia.AutoSize = true;
            this.chkTransparencia.Font = new System.Drawing.Font("Arial", 12F);
            this.chkTransparencia.Location = new System.Drawing.Point(10, 546);
            this.chkTransparencia.Name = "chkTransparencia";
            this.chkTransparencia.Size = new System.Drawing.Size(126, 22);
            this.chkTransparencia.TabIndex = 34;
            this.chkTransparencia.Text = "Transparencia";
            this.chkTransparencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransparencia.UseVisualStyleBackColor = true;
            this.chkTransparencia.CheckedChanged += new System.EventHandler(this.chkTransparencia_CheckedChanged);
            // 
            // FrmControlSuavizadoInteractivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(136, 580);
            this.Controls.Add(this.chkTransparencia);
            this.Controls.Add(this.lblSuavizar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbSuavizado);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControlSuavizadoInteractivo";
            this.Text = "Suavizado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmControlSuavizadoInteractivo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbSuavizado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSuavizar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tbSuavizado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkTransparencia;
    }
}