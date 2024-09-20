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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSenal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnCargarSenal = new System.Windows.Forms.Button();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAbrirTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrx = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportarATablaC = new System.Windows.Forms.ToolStripButton();
            this.tsbExportarProteus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbResetZoom = new System.Windows.Forms.ToolStripButton();
            this.tsbMetricas = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.btnIniciarLectura = new System.Windows.Forms.Button();
            this.btnFinalizarLectura = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartSenal
            // 
            this.chartSenal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartSenal.BorderlineColor = System.Drawing.Color.Black;
            chartArea4.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea4.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea4.AxisX.Title = "Tiempo[Seg]";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.Maximum = 250D;
            chartArea4.AxisY.Title = "Amplitud";
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea4.Name = "ChartArea1";
            this.chartSenal.ChartAreas.Add(chartArea4);
            this.chartSenal.Location = new System.Drawing.Point(19, 75);
            this.chartSenal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartSenal.Name = "chartSenal";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.MarkerStep = 10;
            series4.Name = "Muestras";
            this.chartSenal.Series.Add(series4);
            this.chartSenal.Size = new System.Drawing.Size(1282, 508);
            this.chartSenal.TabIndex = 1;
            this.chartSenal.Text = "chart1";
            this.chartSenal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartEspectro_MouseClick);
            this.chartSenal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartEspectro_MouseDown);
            // 
            // BtnCargarSenal
            // 
            this.BtnCargarSenal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarSenal.Location = new System.Drawing.Point(354, 7);
            this.BtnCargarSenal.Name = "BtnCargarSenal";
            this.BtnCargarSenal.Size = new System.Drawing.Size(151, 39);
            this.BtnCargarSenal.TabIndex = 2;
            this.BtnCargarSenal.Text = "Cargar Señal";
            this.BtnCargarSenal.UseVisualStyleBackColor = true;
            this.BtnCargarSenal.Click += new System.EventHandler(this.BtnCargarSenal_Click);
            // 
            // BtnMarcadores
            // 
            this.BtnMarcadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMarcadores.Location = new System.Drawing.Point(692, 7);
            this.BtnMarcadores.Name = "BtnMarcadores";
            this.BtnMarcadores.Size = new System.Drawing.Size(128, 38);
            this.BtnMarcadores.TabIndex = 4;
            this.BtnMarcadores.Text = "Marcadores";
            this.BtnMarcadores.UseVisualStyleBackColor = true;
            this.BtnMarcadores.Visible = false;
            this.BtnMarcadores.Click += new System.EventHandler(this.BtnMarcadores_Click);
            // 
            // BtnLineaReferencia
            // 
            this.BtnLineaReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLineaReferencia.Location = new System.Drawing.Point(511, 8);
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
            this.button2.Location = new System.Drawing.Point(826, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 55);
            this.button2.TabIndex = 6;
            this.button2.Text = "2da Serie con DataPoints";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1006, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 55);
            this.button3.TabIndex = 7;
            this.button3.Text = "V.Anott con lineas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1127, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(149, 55);
            this.button4.TabIndex = 8;
            this.button4.Text = "V.Anott con lineas 2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(654, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 38);
            this.button5.TabIndex = 9;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAbrirTrx,
            this.tsbGuardarTrx,
            this.toolStripSeparator2,
            this.tsbExportarATablaC,
            this.tsbExportarProteus,
            this.toolStripSeparator1,
            this.tsbResetZoom,
            this.tsbMetricas});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1307, 55);
            this.toolStrip1.TabIndex = 43;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAbrirTrx
            // 
            this.tsbAbrirTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbrirTrx.Image = global::ECGViewer.Properties.Resources.carpeta_abierta;
            this.tsbAbrirTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbrirTrx.Name = "tsbAbrirTrx";
            this.tsbAbrirTrx.Size = new System.Drawing.Size(52, 52);
            this.tsbAbrirTrx.Text = "Abrir Transaccion";
            this.tsbAbrirTrx.Click += new System.EventHandler(this.tsbAbrirTrx_Click);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // tsbExportarATablaC
            // 
            this.tsbExportarATablaC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportarATablaC.Image = global::ECGViewer.Properties.Resources.export_C;
            this.tsbExportarATablaC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportarATablaC.Name = "tsbExportarATablaC";
            this.tsbExportarATablaC.Size = new System.Drawing.Size(52, 52);
            this.tsbExportarATablaC.Text = "Exportar a tabla lenguaje C";
            // 
            // tsbExportarProteus
            // 
            this.tsbExportarProteus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportarProteus.Image = global::ECGViewer.Properties.Resources.export_Proteus;
            this.tsbExportarProteus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportarProteus.Name = "tsbExportarProteus";
            this.tsbExportarProteus.Size = new System.Drawing.Size(52, 52);
            this.tsbExportarProteus.Text = "Exportar A Archivo Generador Proteus";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // tsbResetZoom
            // 
            this.tsbResetZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbResetZoom.Image = global::ECGViewer.Properties.Resources.Zoom_reset_01;
            this.tsbResetZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResetZoom.Name = "tsbResetZoom";
            this.tsbResetZoom.Size = new System.Drawing.Size(52, 52);
            this.tsbResetZoom.Text = "Reset Zoom";
            this.tsbResetZoom.Click += new System.EventHandler(this.tsbResetZoom_Click);
            // 
            // tsbMetricas
            // 
            this.tsbMetricas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMetricas.Image = global::ECGViewer.Properties.Resources.kpi;
            this.tsbMetricas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMetricas.Name = "tsbMetricas";
            this.tsbMetricas.Size = new System.Drawing.Size(52, 52);
            this.tsbMetricas.Text = "Continuity test";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnFinalizarLectura);
            this.groupBox3.Controls.Add(this.btnIniciarLectura);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cmbBaudRate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbPuertos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(411, 591);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 114);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conexión Serie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "BuadRate";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "50",
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cmbBaudRate.Location = new System.Drawing.Point(98, 74);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(105, 25);
            this.cmbBaudRate.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Puerto";
            // 
            // cmbPuertos
            // 
            this.cmbPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuertos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPuertos.FormattingEnabled = true;
            this.cmbPuertos.Location = new System.Drawing.Point(98, 37);
            this.cmbPuertos.Name = "cmbPuertos";
            this.cmbPuertos.Size = new System.Drawing.Size(105, 25);
            this.cmbPuertos.TabIndex = 11;
            // 
            // btnIniciarLectura
            // 
            this.btnIniciarLectura.Location = new System.Drawing.Point(256, 21);
            this.btnIniciarLectura.Name = "btnIniciarLectura";
            this.btnIniciarLectura.Size = new System.Drawing.Size(139, 39);
            this.btnIniciarLectura.TabIndex = 15;
            this.btnIniciarLectura.Text = "Iniciar Lectura";
            this.btnIniciarLectura.UseVisualStyleBackColor = true;
            this.btnIniciarLectura.Click += new System.EventHandler(this.btnIniciarLectura_Click);
            // 
            // btnFinalizarLectura
            // 
            this.btnFinalizarLectura.Location = new System.Drawing.Point(256, 66);
            this.btnFinalizarLectura.Name = "btnFinalizarLectura";
            this.btnFinalizarLectura.Size = new System.Drawing.Size(139, 39);
            this.btnFinalizarLectura.TabIndex = 16;
            this.btnFinalizarLectura.Text = "Finalizar Lectura";
            this.btnFinalizarLectura.UseVisualStyleBackColor = true;
            this.btnFinalizarLectura.Click += new System.EventHandler(this.btnFinalizarLectura_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 717);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnCargarSenal);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnLineaReferencia);
            this.Controls.Add(this.BtnMarcadores);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartSenal);
            this.Name = "Form1";
            this.Text = "Visor ECG 1 Canal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenal;
        private System.Windows.Forms.Button BtnCargarSenal;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAbrirTrx;
        private System.Windows.Forms.ToolStripButton tsbGuardarTrx;
        private System.Windows.Forms.ToolStripButton tsbExportarATablaC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbResetZoom;
        private System.Windows.Forms.ToolStripButton tsbMetricas;
        private System.Windows.Forms.ToolStripButton tsbExportarProteus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPuertos;
        private System.Windows.Forms.Button btnFinalizarLectura;
        private System.Windows.Forms.Button btnIniciarLectura;
        private System.Windows.Forms.Timer timer1;
    }
}

