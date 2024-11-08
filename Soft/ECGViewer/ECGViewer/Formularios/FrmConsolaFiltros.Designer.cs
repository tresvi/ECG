namespace ECGViewer
{
    partial class FrmConsolaFiltros
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartSenalOriginal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSenalFiltrada = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbResetZoom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPasaBajo = new System.Windows.Forms.ToolStripButton();
            this.tsbPasaAlto = new System.Windows.Forms.ToolStripButton();
            this.tsbPasaBanda = new System.Windows.Forms.ToolStripButton();
            this.tsbNotch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAceptar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbResetSenal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.tgbTipoVista = new ECGViewer.Controles.ToggleButton();
            this.toggleButton1 = new ECGViewer.Controles.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartSenalOriginal
            // 
            this.chartSenalOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartSenalOriginal.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisX.Title = "Tiempo[Seg]";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Maximum = 250D;
            chartArea1.AxisY.Title = "Amplitud";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartAreaEspectro";
            chartArea2.Visible = false;
            this.chartSenalOriginal.ChartAreas.Add(chartArea1);
            this.chartSenalOriginal.ChartAreas.Add(chartArea2);
            this.chartSenalOriginal.Location = new System.Drawing.Point(9, 85);
            this.chartSenalOriginal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartSenalOriginal.Name = "chartSenalOriginal";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.MarkerStep = 10;
            series1.Name = "Muestras";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Name = "Espectro";
            this.chartSenalOriginal.Series.Add(series1);
            this.chartSenalOriginal.Series.Add(series2);
            this.chartSenalOriginal.Size = new System.Drawing.Size(1238, 270);
            this.chartSenalOriginal.TabIndex = 2;
            this.chartSenalOriginal.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Señal Original";
            this.chartSenalOriginal.Titles.Add(title1);
            this.chartSenalOriginal.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chartSenalOriginal_AxisViewChanged);
            // 
            // chartSenalFiltrada
            // 
            this.chartSenalFiltrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartSenalFiltrada.BackColor = System.Drawing.Color.LightGray;
            this.chartSenalFiltrada.BorderlineColor = System.Drawing.Color.Black;
            chartArea3.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea3.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea3.AxisX.Title = "Tiempo[Seg]";
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea3.AxisY.Maximum = 250D;
            chartArea3.AxisY.Title = "Amplitud";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea3.Name = "ChartArea1";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea4.Name = "ChartAreaEspectro";
            chartArea4.Visible = false;
            this.chartSenalFiltrada.ChartAreas.Add(chartArea3);
            this.chartSenalFiltrada.ChartAreas.Add(chartArea4);
            this.chartSenalFiltrada.Location = new System.Drawing.Point(9, 377);
            this.chartSenalFiltrada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartSenalFiltrada.Name = "chartSenalFiltrada";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.MarkerStep = 10;
            series3.Name = "Muestras";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Name = "Espectro";
            this.chartSenalFiltrada.Series.Add(series3);
            this.chartSenalFiltrada.Series.Add(series4);
            this.chartSenalFiltrada.Size = new System.Drawing.Size(1240, 270);
            this.chartSenalFiltrada.TabIndex = 3;
            this.chartSenalFiltrada.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Señal Filtrada";
            this.chartSenalFiltrada.Titles.Add(title2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(799, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tiempo / Frecuencia";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbResetZoom,
            this.toolStripSeparator1,
            this.tsbPasaBajo,
            this.tsbPasaAlto,
            this.tsbPasaBanda,
            this.tsbNotch,
            this.toolStripSeparator2,
            this.tsbCancelar,
            this.toolStripSeparator4,
            this.tsbAceptar,
            this.toolStripSeparator5,
            this.tsbResetSenal,
            this.toolStripSeparator3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1262, 72);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbResetZoom
            // 
            this.tsbResetZoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbResetZoom.Image = global::ECGViewer.Properties.Resources.Zoom_reset_01_48x48;
            this.tsbResetZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResetZoom.Name = "tsbResetZoom";
            this.tsbResetZoom.Size = new System.Drawing.Size(85, 69);
            this.tsbResetZoom.Text = "Reset Zoom";
            this.tsbResetZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbResetZoom.Click += new System.EventHandler(this.tsbResetZoom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 72);
            // 
            // tsbPasaBajo
            // 
            this.tsbPasaBajo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbPasaBajo.Image = global::ECGViewer.Properties.Resources.LowPass;
            this.tsbPasaBajo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPasaBajo.Name = "tsbPasaBajo";
            this.tsbPasaBajo.Size = new System.Drawing.Size(52, 69);
            this.tsbPasaBajo.Text = "P.Bajo";
            this.tsbPasaBajo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPasaBajo.Click += new System.EventHandler(this.tsbPasaBajo_Click);
            // 
            // tsbPasaAlto
            // 
            this.tsbPasaAlto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbPasaAlto.Image = global::ECGViewer.Properties.Resources.HighPass;
            this.tsbPasaAlto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPasaAlto.Name = "tsbPasaAlto";
            this.tsbPasaAlto.Size = new System.Drawing.Size(52, 69);
            this.tsbPasaAlto.Text = "P. Alto";
            this.tsbPasaAlto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPasaAlto.Click += new System.EventHandler(this.tsbPasaAlto_Click);
            // 
            // tsbPasaBanda
            // 
            this.tsbPasaBanda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbPasaBanda.Image = global::ECGViewer.Properties.Resources.BandPass2;
            this.tsbPasaBanda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPasaBanda.Name = "tsbPasaBanda";
            this.tsbPasaBanda.Size = new System.Drawing.Size(64, 69);
            this.tsbPasaBanda.Text = "P. Banda";
            this.tsbPasaBanda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPasaBanda.Click += new System.EventHandler(this.tsbPasaBanda_Click);
            // 
            // tsbNotch
            // 
            this.tsbNotch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNotch.Image = global::ECGViewer.Properties.Resources.notch;
            this.tsbNotch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNotch.Name = "tsbNotch";
            this.tsbNotch.Size = new System.Drawing.Size(52, 69);
            this.tsbNotch.Text = "Notch";
            this.tsbNotch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNotch.Click += new System.EventHandler(this.tsbNotch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 72);
            // 
            // tsbCancelar
            // 
            this.tsbCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCancelar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbCancelar.Image = global::ECGViewer.Properties.Resources.cancel_48x48;
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(120, 69);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 72);
            // 
            // tsbAceptar
            // 
            this.tsbAceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAceptar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbAceptar.Image = global::ECGViewer.Properties.Resources.accept_48x48;
            this.tsbAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAceptar.Name = "tsbAceptar";
            this.tsbAceptar.Size = new System.Drawing.Size(110, 69);
            this.tsbAceptar.Text = "Aplicar";
            this.tsbAceptar.Click += new System.EventHandler(this.tsbAceptar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 72);
            // 
            // tsbResetSenal
            // 
            this.tsbResetSenal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbResetSenal.Image = global::ECGViewer.Properties.Resources.reset;
            this.tsbResetSenal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResetSenal.Name = "tsbResetSenal";
            this.tsbResetSenal.Size = new System.Drawing.Size(88, 69);
            this.tsbResetSenal.Text = "Reset Filtros";
            this.tsbResetSenal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbResetSenal.Click += new System.EventHandler(this.tsbResetSenal_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 72);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(429, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Vista: Tiempo / Frecuencia";
            // 
            // tgbTipoVista
            // 
            this.tgbTipoVista.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tgbTipoVista.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.tgbTipoVista.Location = new System.Drawing.Point(491, 28);
            this.tgbTipoVista.MinimumSize = new System.Drawing.Size(45, 22);
            this.tgbTipoVista.Name = "tgbTipoVista";
            this.tgbTipoVista.OffBackColor = System.Drawing.Color.Gray;
            this.tgbTipoVista.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tgbTipoVista.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tgbTipoVista.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tgbTipoVista.Size = new System.Drawing.Size(75, 37);
            this.tgbTipoVista.TabIndex = 14;
            this.tgbTipoVista.UseVisualStyleBackColor = false;
            this.tgbTipoVista.CheckedChanged += new System.EventHandler(this.tgbTipoVista_CheckedChanged);
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.BackgroundColor = System.Drawing.Color.Transparent;
            this.toggleButton1.Location = new System.Drawing.Point(854, 18);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(75, 37);
            this.toggleButton1.TabIndex = 11;
            this.toggleButton1.UseVisualStyleBackColor = true;
            // 
            // FrmConsolaFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 656);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tgbTipoVista);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toggleButton1);
            this.Controls.Add(this.chartSenalFiltrada);
            this.Controls.Add(this.chartSenalOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmConsolaFiltros";
            this.Text = "Banco de Filtros";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConsolaFiltros_FormClosed);
            this.Load += new System.EventHandler(this.FrmAplicarFiltro_Load);
            this.Resize += new System.EventHandler(this.FrmAplicarFiltro_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenalOriginal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenalFiltrada;
        private System.Windows.Forms.Label label2;
        private Controles.ToggleButton toggleButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbResetZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPasaBajo;
        private System.Windows.Forms.ToolStripButton tsbPasaAlto;
        private System.Windows.Forms.ToolStripButton tsbPasaBanda;
        private System.Windows.Forms.ToolStripButton tsbNotch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbAceptar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label3;
        private Controles.ToggleButton tgbTipoVista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbResetSenal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}