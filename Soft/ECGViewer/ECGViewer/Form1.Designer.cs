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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSenal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnCargarSenal = new System.Windows.Forms.Button();
            this.BtnResetZoom = new System.Windows.Forms.Button();
            this.BtnMarcadores = new System.Windows.Forms.Button();
            this.BtnLineaReferencia = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.chartSenalFiltrada = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnFiltrarSenal = new System.Windows.Forms.Button();
            this.btnEspectro = new System.Windows.Forms.Button();
            this.BtnFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).BeginInit();
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
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Maximum = 250D;
            chartArea1.AxisY.Title = "Amplitud";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.chartSenal.ChartAreas.Add(chartArea1);
            this.chartSenal.Location = new System.Drawing.Point(48, 66);
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
            this.chartSenal.Size = new System.Drawing.Size(1246, 281);
            this.chartSenal.TabIndex = 1;
            this.chartSenal.Text = "chart1";
            this.chartSenal.Click += new System.EventHandler(this.chartSenal_Click);
            this.chartSenal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartEspectro_MouseClick);
            this.chartSenal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartEspectro_MouseDown);
            // 
            // BtnCargarSenal
            // 
            this.BtnCargarSenal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarSenal.Location = new System.Drawing.Point(12, 20);
            this.BtnCargarSenal.Name = "BtnCargarSenal";
            this.BtnCargarSenal.Size = new System.Drawing.Size(174, 38);
            this.BtnCargarSenal.TabIndex = 2;
            this.BtnCargarSenal.Text = "Cargar Señal";
            this.BtnCargarSenal.UseVisualStyleBackColor = true;
            this.BtnCargarSenal.Click += new System.EventHandler(this.BtnCargarSenal_Click);
            // 
            // BtnResetZoom
            // 
            this.BtnResetZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetZoom.Location = new System.Drawing.Point(248, 11);
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
            this.BtnMarcadores.Location = new System.Drawing.Point(497, 12);
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
            this.BtnLineaReferencia.Location = new System.Drawing.Point(677, 12);
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
            this.button2.Location = new System.Drawing.Point(856, 3);
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
            this.button3.Location = new System.Drawing.Point(1053, 3);
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
            this.button4.Location = new System.Drawing.Point(1111, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 55);
            this.button4.TabIndex = 8;
            this.button4.Text = "V.Anott con lineas 2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(192, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 75);
            this.button5.TabIndex = 9;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chartSenalFiltrada
            // 
            this.chartSenalFiltrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartSenalFiltrada.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea2.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea2.AxisX.Title = "Tiempo[Seg]";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.Maximum = 250D;
            chartArea2.AxisY.Title = "Amplitud";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.Name = "ChartArea1";
            this.chartSenalFiltrada.ChartAreas.Add(chartArea2);
            this.chartSenalFiltrada.Location = new System.Drawing.Point(48, 368);
            this.chartSenalFiltrada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartSenalFiltrada.Name = "chartSenalFiltrada";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.MarkerStep = 10;
            series2.Name = "Muestras";
            this.chartSenalFiltrada.Series.Add(series2);
            this.chartSenalFiltrada.Size = new System.Drawing.Size(1246, 323);
            this.chartSenalFiltrada.TabIndex = 10;
            this.chartSenalFiltrada.Text = "chart1";
            // 
            // BtnFiltrarSenal
            // 
            this.BtnFiltrarSenal.Location = new System.Drawing.Point(19, 124);
            this.BtnFiltrarSenal.Name = "BtnFiltrarSenal";
            this.BtnFiltrarSenal.Size = new System.Drawing.Size(53, 76);
            this.BtnFiltrarSenal.TabIndex = 11;
            this.BtnFiltrarSenal.Text = "Filtrar Señal";
            this.BtnFiltrarSenal.UseVisualStyleBackColor = true;
            this.BtnFiltrarSenal.Click += new System.EventHandler(this.BtnFiltrarSenal_Click);
            // 
            // btnEspectro
            // 
            this.btnEspectro.Location = new System.Drawing.Point(387, 9);
            this.btnEspectro.Name = "btnEspectro";
            this.btnEspectro.Size = new System.Drawing.Size(81, 45);
            this.btnEspectro.TabIndex = 12;
            this.btnEspectro.Text = "Ver Espectro";
            this.btnEspectro.UseVisualStyleBackColor = true;
            this.btnEspectro.Click += new System.EventHandler(this.btnEspectro_Click);
            // 
            // BtnFiltro
            // 
            this.BtnFiltro.Location = new System.Drawing.Point(12, 296);
            this.BtnFiltro.Name = "BtnFiltro";
            this.BtnFiltro.Size = new System.Drawing.Size(54, 64);
            this.BtnFiltro.TabIndex = 13;
            this.BtnFiltro.Text = "Preview Filtro";
            this.BtnFiltro.UseVisualStyleBackColor = true;
            this.BtnFiltro.Click += new System.EventHandler(this.BtnFiltro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 717);
            this.Controls.Add(this.BtnFiltro);
            this.Controls.Add(this.btnEspectro);
            this.Controls.Add(this.BtnFiltrarSenal);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.chartSenalFiltrada);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnLineaReferencia);
            this.Controls.Add(this.BtnMarcadores);
            this.Controls.Add(this.BtnResetZoom);
            this.Controls.Add(this.BtnCargarSenal);
            this.Controls.Add(this.chartSenal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenalFiltrada;
        private System.Windows.Forms.Button BtnFiltrarSenal;
        private System.Windows.Forms.Button btnEspectro;
        private System.Windows.Forms.Button BtnFiltro;
    }
}

