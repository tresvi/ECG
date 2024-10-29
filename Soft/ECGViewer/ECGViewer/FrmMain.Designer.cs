namespace ECGViewer
{
    partial class FrmMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.chartSenal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnCargarSenal = new System.Windows.Forms.Button();
            this.gbSenal = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTMuestreo = new System.Windows.Forms.NumericUpDown();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.timerPuerto = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timerGraficar = new System.Windows.Forms.Timer(this.components);
            this.lblRegla = new System.Windows.Forms.Label();
            this.btnFinalizarLectura = new System.Windows.Forms.Button();
            this.btnIniciarLectura = new System.Windows.Forms.Button();
            this.tsbNuevoArchivo = new System.Windows.Forms.ToolStripButton();
            this.tsbAbrirTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbResetZoom = new System.Windows.Forms.ToolStripButton();
            this.tsbReglaX = new System.Windows.Forms.ToolStripButton();
            this.tsbGridECG = new System.Windows.Forms.ToolStripButton();
            this.tsbTijera = new System.Windows.Forms.ToolStripButton();
            this.tsbAdminMarcadores = new System.Windows.Forms.ToolStripButton();
            this.tsbCalibracion = new System.Windows.Forms.ToolStripButton();
            this.tsbImportarDesdeXLSX = new System.Windows.Forms.ToolStripButton();
            this.tsbExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbExportarATablaC = new System.Windows.Forms.ToolStripButton();
            this.tsbExportarProteus = new System.Windows.Forms.ToolStripButton();
            this.tsbMetricas = new System.Windows.Forms.ToolStripButton();
            this.btnFiltrarSenal = new System.Windows.Forms.Button();
            this.btnEspectro = new System.Windows.Forms.Button();
            this.btnFiltrosAvanzados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).BeginInit();
            this.gbSenal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTMuestreo)).BeginInit();
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
            chartArea1.AxisY.Title = "mV";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.chartSenal.ChartAreas.Add(chartArea1);
            this.chartSenal.Location = new System.Drawing.Point(0, 75);
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
            this.chartSenal.Size = new System.Drawing.Size(1230, 473);
            this.chartSenal.TabIndex = 1;
            this.chartSenal.Text = "chart1";
            this.chartSenal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartSenal_MouseClick);
            this.chartSenal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartSenal_MouseDown);
            this.chartSenal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartSenal_MouseMove);
            this.chartSenal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chartSenal_MouseUp);
            // 
            // BtnCargarSenal
            // 
            this.BtnCargarSenal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarSenal.Location = new System.Drawing.Point(1138, 6);
            this.BtnCargarSenal.Name = "BtnCargarSenal";
            this.BtnCargarSenal.Size = new System.Drawing.Size(96, 48);
            this.BtnCargarSenal.TabIndex = 2;
            this.BtnCargarSenal.Text = "Cargar Señal";
            this.BtnCargarSenal.UseVisualStyleBackColor = true;
            this.BtnCargarSenal.Visible = false;
            this.BtnCargarSenal.Click += new System.EventHandler(this.BtnCargarSenal_Click);
            // 
            // gbSenal
            // 
            this.gbSenal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSenal.Controls.Add(this.btnFiltrarSenal);
            this.gbSenal.Controls.Add(this.btnEspectro);
            this.gbSenal.Controls.Add(this.btnFiltrosAvanzados);
            this.gbSenal.Enabled = false;
            this.gbSenal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSenal.Location = new System.Drawing.Point(639, 556);
            this.gbSenal.Name = "gbSenal";
            this.gbSenal.Size = new System.Drawing.Size(387, 118);
            this.gbSenal.TabIndex = 14;
            this.gbSenal.TabStop = false;
            this.gbSenal.Text = "Señal";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevoArchivo,
            this.tsbAbrirTrx,
            this.tsbGuardarTrx,
            this.toolStripSeparator7,
            this.toolStripSeparator4,
            this.tsbImprimir,
            this.toolStripSeparator6,
            this.toolStripSeparator5,
            this.tsbResetZoom,
            this.tsbReglaX,
            this.tsbGridECG,
            this.tsbTijera,
            this.tsbAdminMarcadores,
            this.tsbCalibracion,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.tsbImportarDesdeXLSX,
            this.tsbExportarExcel,
            this.tsbExportarATablaC,
            this.tsbExportarProteus,
            this.toolStripSeparator3,
            this.tsbMetricas});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1230, 71);
            this.toolStrip1.TabIndex = 43;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 71);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nudTMuestreo);
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Controls.Add(this.btnFinalizarLectura);
            this.groupBox3.Controls.Add(this.btnIniciarLectura);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cmbBaudRate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbPuertos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(19, 556);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 118);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Captura por puerto COM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "T.Muestreo [ms]";
            // 
            // nudTMuestreo
            // 
            this.nudTMuestreo.DecimalPlaces = 1;
            this.nudTMuestreo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTMuestreo.Location = new System.Drawing.Point(125, 84);
            this.nudTMuestreo.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudTMuestreo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTMuestreo.Name = "nudTMuestreo";
            this.nudTMuestreo.Size = new System.Drawing.Size(105, 25);
            this.nudTMuestreo.TabIndex = 18;
            this.nudTMuestreo.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(413, 21);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(178, 84);
            this.txtLog.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 59);
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
            this.cmbBaudRate.Location = new System.Drawing.Point(125, 53);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(105, 25);
            this.cmbBaudRate.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 28);
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
            this.cmbPuertos.Location = new System.Drawing.Point(125, 22);
            this.cmbPuertos.Name = "cmbPuertos";
            this.cmbPuertos.Size = new System.Drawing.Size(105, 25);
            this.cmbPuertos.TabIndex = 11;
            // 
            // timerPuerto
            // 
            this.timerPuerto.Interval = 250;
            this.timerPuerto.Tick += new System.EventHandler(this.timerPuerto_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1128, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 48);
            this.button1.TabIndex = 45;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // timerGraficar
            // 
            this.timerGraficar.Interval = 250;
            this.timerGraficar.Tick += new System.EventHandler(this.timerGrafico_Tick);
            // 
            // lblRegla
            // 
            this.lblRegla.AutoSize = true;
            this.lblRegla.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblRegla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRegla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegla.ForeColor = System.Drawing.Color.Red;
            this.lblRegla.Location = new System.Drawing.Point(1096, 599);
            this.lblRegla.Name = "lblRegla";
            this.lblRegla.Size = new System.Drawing.Size(78, 27);
            this.lblRegla.TabIndex = 46;
            this.lblRegla.Text = "label4";
            this.lblRegla.Visible = false;
            // 
            // btnFinalizarLectura
            // 
            this.btnFinalizarLectura.Enabled = false;
            this.btnFinalizarLectura.Image = global::ECGViewer.Properties.Resources.stop;
            this.btnFinalizarLectura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizarLectura.Location = new System.Drawing.Point(255, 66);
            this.btnFinalizarLectura.Name = "btnFinalizarLectura";
            this.btnFinalizarLectura.Size = new System.Drawing.Size(150, 39);
            this.btnFinalizarLectura.TabIndex = 16;
            this.btnFinalizarLectura.Text = "Finalizar Lectura";
            this.btnFinalizarLectura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinalizarLectura.UseVisualStyleBackColor = true;
            this.btnFinalizarLectura.Click += new System.EventHandler(this.btnFinalizarLectura_Click);
            // 
            // btnIniciarLectura
            // 
            this.btnIniciarLectura.Image = global::ECGViewer.Properties.Resources.play_button;
            this.btnIniciarLectura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarLectura.Location = new System.Drawing.Point(255, 21);
            this.btnIniciarLectura.Name = "btnIniciarLectura";
            this.btnIniciarLectura.Size = new System.Drawing.Size(150, 39);
            this.btnIniciarLectura.TabIndex = 15;
            this.btnIniciarLectura.Text = "Iniciar Lectura";
            this.btnIniciarLectura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciarLectura.UseVisualStyleBackColor = true;
            this.btnIniciarLectura.Click += new System.EventHandler(this.btnIniciarLectura_Click);
            // 
            // tsbNuevoArchivo
            // 
            this.tsbNuevoArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevoArchivo.Image = global::ECGViewer.Properties.Resources.new_file;
            this.tsbNuevoArchivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoArchivo.Name = "tsbNuevoArchivo";
            this.tsbNuevoArchivo.Size = new System.Drawing.Size(68, 68);
            this.tsbNuevoArchivo.Text = "Nuevo Archivo";
            this.tsbNuevoArchivo.Click += new System.EventHandler(this.tsbNuevoArchivo_Click);
            // 
            // tsbAbrirTrx
            // 
            this.tsbAbrirTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbrirTrx.Image = global::ECGViewer.Properties.Resources.carpeta_abierta;
            this.tsbAbrirTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbrirTrx.Name = "tsbAbrirTrx";
            this.tsbAbrirTrx.Size = new System.Drawing.Size(68, 68);
            this.tsbAbrirTrx.Text = "Abrir Transaccion";
            this.tsbAbrirTrx.Click += new System.EventHandler(this.tsbAbrirTrx_Click);
            // 
            // tsbGuardarTrx
            // 
            this.tsbGuardarTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardarTrx.Image = global::ECGViewer.Properties.Resources.disco_flexible__1_;
            this.tsbGuardarTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarTrx.Name = "tsbGuardarTrx";
            this.tsbGuardarTrx.Size = new System.Drawing.Size(68, 68);
            this.tsbGuardarTrx.Text = "Guardar Transaccion";
            this.tsbGuardarTrx.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImprimir.Image = global::ECGViewer.Properties.Resources.printer;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(68, 68);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Click += new System.EventHandler(this.tsbImprimir_Click);
            // 
            // tsbResetZoom
            // 
            this.tsbResetZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbResetZoom.Image = global::ECGViewer.Properties.Resources.Zoom_reset_01;
            this.tsbResetZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResetZoom.Name = "tsbResetZoom";
            this.tsbResetZoom.Size = new System.Drawing.Size(68, 68);
            this.tsbResetZoom.Text = "Reset Zoom";
            this.tsbResetZoom.Click += new System.EventHandler(this.tsbResetZoom_Click);
            // 
            // tsbReglaX
            // 
            this.tsbReglaX.CheckOnClick = true;
            this.tsbReglaX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReglaX.Image = global::ECGViewer.Properties.Resources.ruler1;
            this.tsbReglaX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReglaX.Name = "tsbReglaX";
            this.tsbReglaX.Size = new System.Drawing.Size(68, 68);
            this.tsbReglaX.Text = "Regla";
            this.tsbReglaX.Click += new System.EventHandler(this.tsbReglaX_Click);
            // 
            // tsbGridECG
            // 
            this.tsbGridECG.CheckOnClick = true;
            this.tsbGridECG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGridECG.Image = global::ECGViewer.Properties.Resources.grid;
            this.tsbGridECG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGridECG.Name = "tsbGridECG";
            this.tsbGridECG.Size = new System.Drawing.Size(68, 68);
            this.tsbGridECG.Text = "Activar Grilla ECG";
            this.tsbGridECG.Click += new System.EventHandler(this.tsbGridECG_Click);
            // 
            // tsbTijera
            // 
            this.tsbTijera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTijera.Image = global::ECGViewer.Properties.Resources.scisors;
            this.tsbTijera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTijera.Name = "tsbTijera";
            this.tsbTijera.Size = new System.Drawing.Size(68, 68);
            this.tsbTijera.Text = "Cortar Grafico";
            this.tsbTijera.Click += new System.EventHandler(this.tsbTijera_Click);
            // 
            // tsbAdminMarcadores
            // 
            this.tsbAdminMarcadores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdminMarcadores.Image = global::ECGViewer.Properties.Resources.marker;
            this.tsbAdminMarcadores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdminMarcadores.Name = "tsbAdminMarcadores";
            this.tsbAdminMarcadores.Size = new System.Drawing.Size(68, 68);
            this.tsbAdminMarcadores.Text = "Administrar Marcadores";
            this.tsbAdminMarcadores.Click += new System.EventHandler(this.tsbAdminMarcadores_Click);
            // 
            // tsbCalibracion
            // 
            this.tsbCalibracion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCalibracion.Image = global::ECGViewer.Properties.Resources.measurement;
            this.tsbCalibracion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCalibracion.Name = "tsbCalibracion";
            this.tsbCalibracion.Size = new System.Drawing.Size(68, 68);
            this.tsbCalibracion.Text = "Calibracion";
            this.tsbCalibracion.Click += new System.EventHandler(this.tsbCalibracion_Click);
            // 
            // tsbImportarDesdeXLSX
            // 
            this.tsbImportarDesdeXLSX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImportarDesdeXLSX.Image = global::ECGViewer.Properties.Resources.Import_From_xlsx;
            this.tsbImportarDesdeXLSX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportarDesdeXLSX.Name = "tsbImportarDesdeXLSX";
            this.tsbImportarDesdeXLSX.Size = new System.Drawing.Size(68, 68);
            this.tsbImportarDesdeXLSX.Text = "Importar desde XLSX";
            this.tsbImportarDesdeXLSX.Click += new System.EventHandler(this.tsbImportarDesdeXLSX_Click);
            // 
            // tsbExportarExcel
            // 
            this.tsbExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportarExcel.Image = global::ECGViewer.Properties.Resources.export_to_xlsx_2;
            this.tsbExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportarExcel.Name = "tsbExportarExcel";
            this.tsbExportarExcel.Size = new System.Drawing.Size(68, 68);
            this.tsbExportarExcel.Text = "Exportar a XLSX";
            this.tsbExportarExcel.Click += new System.EventHandler(this.tsbExportarExcel_Click);
            // 
            // tsbExportarATablaC
            // 
            this.tsbExportarATablaC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportarATablaC.Image = global::ECGViewer.Properties.Resources.export_C;
            this.tsbExportarATablaC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportarATablaC.Name = "tsbExportarATablaC";
            this.tsbExportarATablaC.Size = new System.Drawing.Size(68, 68);
            this.tsbExportarATablaC.Text = "Exportar a tabla lenguaje C";
            this.tsbExportarATablaC.Click += new System.EventHandler(this.tsbExportarATablaC_Click);
            // 
            // tsbExportarProteus
            // 
            this.tsbExportarProteus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportarProteus.Image = global::ECGViewer.Properties.Resources.export_Proteus;
            this.tsbExportarProteus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportarProteus.Name = "tsbExportarProteus";
            this.tsbExportarProteus.Size = new System.Drawing.Size(68, 68);
            this.tsbExportarProteus.Text = "Exportar A Archivo Generador Proteus";
            this.tsbExportarProteus.Click += new System.EventHandler(this.tsbExportarProteus_Click);
            // 
            // tsbMetricas
            // 
            this.tsbMetricas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMetricas.Image = global::ECGViewer.Properties.Resources.kpi;
            this.tsbMetricas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMetricas.Name = "tsbMetricas";
            this.tsbMetricas.Size = new System.Drawing.Size(68, 68);
            this.tsbMetricas.Text = "Continuity test";
            this.tsbMetricas.Visible = false;
            this.tsbMetricas.Click += new System.EventHandler(this.tsbMetricas_Click);
            // 
            // btnFiltrarSenal
            // 
            this.btnFiltrarSenal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFiltrarSenal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarSenal.Image = global::ECGViewer.Properties.Resources.LowPass48x48;
            this.btnFiltrarSenal.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltrarSenal.Location = new System.Drawing.Point(20, 24);
            this.btnFiltrarSenal.Name = "btnFiltrarSenal";
            this.btnFiltrarSenal.Size = new System.Drawing.Size(108, 85);
            this.btnFiltrarSenal.TabIndex = 12;
            this.btnFiltrarSenal.Text = "Filtro PB 50Hz";
            this.btnFiltrarSenal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFiltrarSenal.UseVisualStyleBackColor = true;
            this.btnFiltrarSenal.Click += new System.EventHandler(this.BtnFiltrarSenal_Click);
            // 
            // btnEspectro
            // 
            this.btnEspectro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEspectro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspectro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEspectro.Image = global::ECGViewer.Properties.Resources.spectrum48x48;
            this.btnEspectro.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEspectro.Location = new System.Drawing.Point(262, 24);
            this.btnEspectro.Name = "btnEspectro";
            this.btnEspectro.Size = new System.Drawing.Size(105, 85);
            this.btnEspectro.TabIndex = 12;
            this.btnEspectro.Text = "Espectro";
            this.btnEspectro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEspectro.UseVisualStyleBackColor = true;
            this.btnEspectro.Click += new System.EventHandler(this.btnEspectro_Click);
            // 
            // btnFiltrosAvanzados
            // 
            this.btnFiltrosAvanzados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFiltrosAvanzados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrosAvanzados.Image = global::ECGViewer.Properties.Resources.spectrum_2_48x48;
            this.btnFiltrosAvanzados.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltrosAvanzados.Location = new System.Drawing.Point(138, 24);
            this.btnFiltrosAvanzados.Name = "btnFiltrosAvanzados";
            this.btnFiltrosAvanzados.Size = new System.Drawing.Size(114, 85);
            this.btnFiltrosAvanzados.TabIndex = 13;
            this.btnFiltrosAvanzados.Text = "Filtros Avanzados";
            this.btnFiltrosAvanzados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFiltrosAvanzados.UseVisualStyleBackColor = true;
            this.btnFiltrosAvanzados.Click += new System.EventHandler(this.BtnFiltroAvanzados_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 682);
            this.Controls.Add(this.lblRegla);
            this.Controls.Add(this.BtnCargarSenal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbSenal);
            this.Controls.Add(this.chartSenal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Visor ECG 1 Canal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).EndInit();
            this.gbSenal.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTMuestreo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenal;
        private System.Windows.Forms.Button BtnCargarSenal;
        private System.Windows.Forms.Button btnEspectro;
        private System.Windows.Forms.Button btnFiltrosAvanzados;
        private System.Windows.Forms.GroupBox gbSenal;
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
        private System.Windows.Forms.Timer timerPuerto;
        private System.Windows.Forms.ToolStripButton tsbNuevoArchivo;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTMuestreo;
        private System.Windows.Forms.ToolStripButton tsbTijera;
        private System.Windows.Forms.ToolStripButton tsbCalibracion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbAdminMarcadores;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbExportarExcel;
        private System.Windows.Forms.ToolStripButton tsbGridECG;
        private System.Windows.Forms.ToolStripButton tsbImportarDesdeXLSX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerGraficar;
        private System.Windows.Forms.ToolStripButton tsbReglaX;
        private System.Windows.Forms.Label lblRegla;
    }
}

