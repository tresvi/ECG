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
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.BtnCargar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnFiltroNotch = new System.Windows.Forms.Button();
            this.BtnFiltroPasaBanda = new System.Windows.Forms.Button();
            this.BtnFiltroPasaAlto = new System.Windows.Forms.Button();
            this.BtnFiltroPasaBajo = new System.Windows.Forms.Button();
            this.BtnResetZoom = new System.Windows.Forms.Button();
            this.tgbTipoVista = new ECGViewer.Controles.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).BeginInit();
            this.gbButtons.SuspendLayout();
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
            this.chartSenalOriginal.Location = new System.Drawing.Point(11, 95);
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
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Señal Filtrada";
            this.chartSenalFiltrada.Titles.Add(title2);
            // 
            // gbButtons
            // 
            this.gbButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbButtons.Controls.Add(this.BtnCargar);
            this.gbButtons.Controls.Add(this.BtnGuardar);
            this.gbButtons.Controls.Add(this.label1);
            this.gbButtons.Controls.Add(this.BtnFiltroNotch);
            this.gbButtons.Controls.Add(this.BtnFiltroPasaBanda);
            this.gbButtons.Controls.Add(this.BtnFiltroPasaAlto);
            this.gbButtons.Controls.Add(this.BtnFiltroPasaBajo);
            this.gbButtons.Controls.Add(this.BtnResetZoom);
            this.gbButtons.Controls.Add(this.tgbTipoVista);
            this.gbButtons.Location = new System.Drawing.Point(12, 7);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(1238, 78);
            this.gbButtons.TabIndex = 5;
            this.gbButtons.TabStop = false;
            // 
            // BtnCargar
            // 
            this.BtnCargar.Location = new System.Drawing.Point(912, 15);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(73, 52);
            this.BtnCargar.TabIndex = 12;
            this.BtnCargar.Text = "Cargar Perfil Filtros";
            this.BtnCargar.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(833, 15);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(73, 52);
            this.BtnGuardar.TabIndex = 11;
            this.BtnGuardar.Text = "Guardar Pefil Filtros";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tiempo / Frecuencia";
            // 
            // BtnFiltroNotch
            // 
            this.BtnFiltroNotch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltroNotch.Location = new System.Drawing.Point(649, 19);
            this.BtnFiltroNotch.Name = "BtnFiltroNotch";
            this.BtnFiltroNotch.Size = new System.Drawing.Size(110, 47);
            this.BtnFiltroNotch.TabIndex = 9;
            this.BtnFiltroNotch.Text = "Filtro Notch";
            this.BtnFiltroNotch.UseVisualStyleBackColor = true;
            this.BtnFiltroNotch.Click += new System.EventHandler(this.BtnFiltroNotch_Click);
            // 
            // BtnFiltroPasaBanda
            // 
            this.BtnFiltroPasaBanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltroPasaBanda.Location = new System.Drawing.Point(533, 19);
            this.BtnFiltroPasaBanda.Name = "BtnFiltroPasaBanda";
            this.BtnFiltroPasaBanda.Size = new System.Drawing.Size(110, 47);
            this.BtnFiltroPasaBanda.TabIndex = 8;
            this.BtnFiltroPasaBanda.Text = "Filtro Pasa Banda";
            this.BtnFiltroPasaBanda.UseVisualStyleBackColor = true;
            this.BtnFiltroPasaBanda.Click += new System.EventHandler(this.BtnFiltroPasaBanda_Click);
            // 
            // BtnFiltroPasaAlto
            // 
            this.BtnFiltroPasaAlto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltroPasaAlto.Location = new System.Drawing.Point(417, 19);
            this.BtnFiltroPasaAlto.Name = "BtnFiltroPasaAlto";
            this.BtnFiltroPasaAlto.Size = new System.Drawing.Size(110, 47);
            this.BtnFiltroPasaAlto.TabIndex = 7;
            this.BtnFiltroPasaAlto.Text = "Filtro Pasa Alto";
            this.BtnFiltroPasaAlto.UseVisualStyleBackColor = true;
            this.BtnFiltroPasaAlto.Click += new System.EventHandler(this.BtnFiltroPasaAlto_Click);
            // 
            // BtnFiltroPasaBajo
            // 
            this.BtnFiltroPasaBajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltroPasaBajo.Location = new System.Drawing.Point(301, 19);
            this.BtnFiltroPasaBajo.Name = "BtnFiltroPasaBajo";
            this.BtnFiltroPasaBajo.Size = new System.Drawing.Size(110, 47);
            this.BtnFiltroPasaBajo.TabIndex = 6;
            this.BtnFiltroPasaBajo.Text = "Filtro Pasa Bajo";
            this.BtnFiltroPasaBajo.UseVisualStyleBackColor = true;
            this.BtnFiltroPasaBajo.Click += new System.EventHandler(this.BtnFiltroPasaBajo_Click);
            // 
            // BtnResetZoom
            // 
            this.BtnResetZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetZoom.Location = new System.Drawing.Point(196, 19);
            this.BtnResetZoom.Name = "BtnResetZoom";
            this.BtnResetZoom.Size = new System.Drawing.Size(71, 48);
            this.BtnResetZoom.TabIndex = 5;
            this.BtnResetZoom.Text = "Reset Zoom";
            this.BtnResetZoom.UseVisualStyleBackColor = true;
            this.BtnResetZoom.Click += new System.EventHandler(this.BtnResetZoom_Click);
            // 
            // tgbTipoVista
            // 
            this.tgbTipoVista.Location = new System.Drawing.Point(51, 32);
            this.tgbTipoVista.MinimumSize = new System.Drawing.Size(45, 22);
            this.tgbTipoVista.Name = "tgbTipoVista";
            this.tgbTipoVista.OffBackColor = System.Drawing.Color.Gray;
            this.tgbTipoVista.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tgbTipoVista.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tgbTipoVista.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tgbTipoVista.Size = new System.Drawing.Size(75, 37);
            this.tgbTipoVista.TabIndex = 0;
            this.tgbTipoVista.UseVisualStyleBackColor = true;
            this.tgbTipoVista.CheckedChanged += new System.EventHandler(this.tgbTipoVista_CheckedChanged);
            // 
            // FrmConsolaFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 656);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.chartSenalFiltrada);
            this.Controls.Add(this.chartSenalOriginal);
            this.Name = "FrmConsolaFiltros";
            this.Text = "Banco de Filtros";
            this.Load += new System.EventHandler(this.FrmAplicarFiltro_Load);
            this.Resize += new System.EventHandler(this.FrmAplicarFiltro_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).EndInit();
            this.gbButtons.ResumeLayout(false);
            this.gbButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenalOriginal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenalFiltrada;
        private System.Windows.Forms.GroupBox gbButtons;
        private Controles.ToggleButton tgbTipoVista;
        private System.Windows.Forms.Button BtnResetZoom;
        private System.Windows.Forms.Button BtnFiltroNotch;
        private System.Windows.Forms.Button BtnFiltroPasaBanda;
        private System.Windows.Forms.Button BtnFiltroPasaAlto;
        private System.Windows.Forms.Button BtnFiltroPasaBajo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.Button BtnGuardar;
    }
}