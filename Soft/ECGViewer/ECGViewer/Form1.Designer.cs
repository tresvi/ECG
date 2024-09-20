namespace ECGViewer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSenal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnCargarSenal = new System.Windows.Forms.Button();
            this.BtnResetZoom = new System.Windows.Forms.Button();
            this.BtnMarcadores = new System.Windows.Forms.Button();
            this.BtnLineaReferencia = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnEspectro = new System.Windows.Forms.Button();
            this.btnFiltrosAvanzados = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrarSenal = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbContinutyTest = new System.Windows.Forms.ToolStripButton();
            this.tsbMedidasRendimiento = new System.Windows.Forms.ToolStripButton();
            this.tsbAbrirTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrxComo = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadTest = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartSenal
            // 
            this.chartSenal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartSenal.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisX.Title = "Tiempo[Seg]";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Maximum = 250D;
            chartArea1.AxisY.Title = "Amplitud";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.chartSenal.ChartAreas.Add(chartArea1);
            this.chartSenal.Location = new System.Drawing.Point(19, 112);
            this.chartSenal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartSenal.Name = "chartSenal";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.MarkerStep = 10;
            series1.Name = "Muestras";
            this.chartSenal.Series.Add(series1);
            this.chartSenal.Size = new System.Drawing.Size(1282, 471);
            this.chartSenal.TabIndex = 1;
            this.chartSenal.Text = "chart1";
            this.chartSenal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartEspectro_MouseClick);
            this.chartSenal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartEspectro_MouseDown);
            // 
            // BtnCargarSenal
            // 
            this.BtnCargarSenal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarSenal.Location = new System.Drawing.Point(180, 65);
            this.BtnCargarSenal.Name = "BtnCargarSenal";
            this.BtnCargarSenal.Size = new System.Drawing.Size(174, 39);
            this.BtnCargarSenal.TabIndex = 2;
            this.BtnCargarSenal.Text = "Cargar Señal";
            this.BtnCargarSenal.UseVisualStyleBackColor = true;
            this.BtnCargarSenal.Click += new System.EventHandler(this.BtnCargarSenal_Click);
            // 
            // BtnResetZoom
            // 
            this.BtnResetZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetZoom.Location = new System.Drawing.Point(19, 58);
            this.BtnResetZoom.Name = "BtnResetZoom";
            this.BtnResetZoom.Size = new System.Drawing.Size(121, 38);
            this.BtnResetZoom.TabIndex = 3;
            this.BtnResetZoom.Text = "Reset Zoom";
            this.BtnResetZoom.UseVisualStyleBackColor = true;
            this.BtnResetZoom.Click += new System.EventHandler(this.BtnResetZoom_Click);
            // 
            // BtnMarcadores
            // 
            this.BtnMarcadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMarcadores.Location = new System.Drawing.Point(441, 58);
            this.BtnMarcadores.Name = "BtnMarcadores";
            this.BtnMarcadores.Size = new System.Drawing.Size(174, 38);
            this.BtnMarcadores.TabIndex = 4;
            this.BtnMarcadores.Text = "Marcadores";
            this.BtnMarcadores.UseVisualStyleBackColor = true;
            this.BtnMarcadores.Click += new System.EventHandler(this.BtnMarcadores_Click);
            // 
            // BtnLineaReferencia
            // 
            this.BtnLineaReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLineaReferencia.Location = new System.Drawing.Point(621, 58);
            this.BtnLineaReferencia.Name = "BtnLineaReferencia";
            this.BtnLineaReferencia.Size = new System.Drawing.Size(174, 38);
            this.BtnLineaReferencia.TabIndex = 5;
            this.BtnLineaReferencia.Text = "Linea de referencia";
            this.BtnLineaReferencia.UseVisualStyleBackColor = true;
            this.BtnLineaReferencia.Click += new System.EventHandler(this.BtnLineaReferencia_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(801, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 55);
            this.button2.TabIndex = 6;
            this.button2.Text = "2da Serie con DataPoints";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(981, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 55);
            this.button3.TabIndex = 7;
            this.button3.Text = "V.Anott con lineas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1175, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 55);
            this.button4.TabIndex = 8;
            this.button4.Text = "V.Anott con lineas 2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(385, 29);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 75);
            this.button5.TabIndex = 9;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnEspectro
            // 
            this.btnEspectro.Enabled = false;
            this.btnEspectro.Location = new System.Drawing.Point(267, 21);
            this.btnEspectro.Name = "btnEspectro";
            this.btnEspectro.Size = new System.Drawing.Size(99, 78);
            this.btnEspectro.TabIndex = 12;
            this.btnEspectro.Text = "Ver Espectro";
            this.btnEspectro.UseVisualStyleBackColor = true;
            this.btnEspectro.Click += new System.EventHandler(this.btnEspectro_Click);
            // 
            // btnFiltrosAvanzados
            // 
            this.btnFiltrosAvanzados.Enabled = false;
            this.btnFiltrosAvanzados.Location = new System.Drawing.Point(135, 21);
            this.btnFiltrosAvanzados.Name = "btnFiltrosAvanzados";
            this.btnFiltrosAvanzados.Size = new System.Drawing.Size(114, 78);
            this.btnFiltrosAvanzados.TabIndex = 13;
            this.btnFiltrosAvanzados.Text = "Filtros Avanzados";
            this.btnFiltrosAvanzados.UseVisualStyleBackColor = true;
            this.btnFiltrosAvanzados.Click += new System.EventHandler(this.BtnFiltro_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnFiltrarSenal);
            this.groupBox1.Controls.Add(this.btnEspectro);
            this.groupBox1.Controls.Add(this.btnFiltrosAvanzados);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 591);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 114);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Señal";
            // 
            // btnFiltrarSenal
            // 
            this.btnFiltrarSenal.Enabled = false;
            this.btnFiltrarSenal.Location = new System.Drawing.Point(11, 21);
            this.btnFiltrarSenal.Name = "btnFiltrarSenal";
            this.btnFiltrarSenal.Size = new System.Drawing.Size(101, 78);
            this.btnFiltrarSenal.TabIndex = 12;
            this.btnFiltrarSenal.Text = "Aplicar Filtro P.Bajo 50Hz";
            this.btnFiltrarSenal.UseVisualStyleBackColor = true;
            this.btnFiltrarSenal.Click += new System.EventHandler(this.BtnFiltrarSenal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(411, 591);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 114);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Puerto Serie";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAbrirTrx,
            this.tsbGuardarTrx,
            this.tsbGuardarTrxComo,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.tsbLoadTest,
            this.tsbContinutyTest,
            this.tsbMedidasRendimiento});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1307, 55);
            this.toolStrip1.TabIndex = 43;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // tsbContinutyTest
            // 
            this.tsbContinutyTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbContinutyTest.Image = global::ECGViewer.Properties.Resources.kpi;
            this.tsbContinutyTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContinutyTest.Name = "tsbContinutyTest";
            this.tsbContinutyTest.Size = new System.Drawing.Size(52, 52);
            this.tsbContinutyTest.Text = "Continuity test";
            // 
            // tsbMedidasRendimiento
            // 
            this.tsbMedidasRendimiento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMedidasRendimiento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMedidasRendimiento.Name = "tsbMedidasRendimiento";
            this.tsbMedidasRendimiento.Size = new System.Drawing.Size(23, 52);
            this.tsbMedidasRendimiento.Text = "Medidas de Rendimiento";
            // 
            // tsbAbrirTrx
            // 
            this.tsbAbrirTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbrirTrx.Image = global::ECGViewer.Properties.Resources.carpeta_abierta;
            this.tsbAbrirTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbrirTrx.Name = "tsbAbrirTrx";
            this.tsbAbrirTrx.Size = new System.Drawing.Size(52, 52);
            this.tsbAbrirTrx.Text = "Abrir Transaccion";
            // 
            // tsbGuardarTrx
            // 
            this.tsbGuardarTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardarTrx.Image = global::ECGViewer.Properties.Resources.disco_flexible__1_;
            this.tsbGuardarTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarTrx.Name = "tsbGuardarTrx";
            this.tsbGuardarTrx.Size = new System.Drawing.Size(52, 52);
            this.tsbGuardarTrx.Text = "Guardar Transaccion";
            // 
            // tsbGuardarTrxComo
            // 
            this.tsbGuardarTrxComo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardarTrxComo.Image = global::ECGViewer.Properties.Resources.export;
            this.tsbGuardarTrxComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarTrxComo.Name = "tsbGuardarTrxComo";
            this.tsbGuardarTrxComo.Size = new System.Drawing.Size(52, 52);
            this.tsbGuardarTrxComo.Text = "Guardar Transaccion Como";
            // 
            // tsbLoadTest
            // 
            this.tsbLoadTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadTest.Image = global::ECGViewer.Properties.Resources.Zoom_reset_01;
            this.tsbLoadTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadTest.Name = "tsbLoadTest";
            this.tsbLoadTest.Size = new System.Drawing.Size(52, 52);
            this.tsbLoadTest.Text = "Load Test";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 717);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnLineaReferencia);
            this.Controls.Add(this.BtnMarcadores);
            this.Controls.Add(this.BtnResetZoom);
            this.Controls.Add(this.BtnCargarSenal);
            this.Controls.Add(this.chartSenal);
            this.Name = "Form1";
            this.Text = "Visor ECG 1 Canal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenal;
        private System.Windows.Forms.Button BtnCargarSenal;
        private System.Windows.Forms.Button BtnResetZoom;
        private System.Windows.Forms.Button BtnMarcadores;
        private System.Windows.Forms.Button BtnLineaReferencia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnEspectro;
        private System.Windows.Forms.Button btnFiltrosAvanzados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrarSenal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAbrirTrx;
        private System.Windows.Forms.ToolStripButton tsbGuardarTrx;
        private System.Windows.Forms.ToolStripButton tsbGuardarTrxComo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadTest;
        private System.Windows.Forms.ToolStripButton tsbContinutyTest;
        private System.Windows.Forms.ToolStripButton tsbMedidasRendimiento;
    }
}

