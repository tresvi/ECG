namespace ECGViewer
{
    partial class FrmAplicarFiltro
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartSenalOriginal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSenalFiltrada = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnResetZoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).BeginInit();
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
            this.chartSenalOriginal.ChartAreas.Add(chartArea1);
            this.chartSenalOriginal.Location = new System.Drawing.Point(13, 14);
            this.chartSenalOriginal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartSenalOriginal.Name = "chartSenalOriginal";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.MarkerStep = 10;
            series1.Name = "Muestras";
            this.chartSenalOriginal.Series.Add(series1);
            this.chartSenalOriginal.Size = new System.Drawing.Size(1159, 280);
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
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 15;
            chartArea2.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea2.AxisX.Title = "Tiempo[Seg]";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.Maximum = 250D;
            chartArea2.AxisY.Title = "Amplitud";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.Name = "ChartArea1";
            this.chartSenalFiltrada.ChartAreas.Add(chartArea2);
            this.chartSenalFiltrada.Location = new System.Drawing.Point(13, 310);
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
            this.chartSenalFiltrada.Size = new System.Drawing.Size(1159, 280);
            this.chartSenalFiltrada.TabIndex = 3;
            this.chartSenalFiltrada.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Señal Filtrada";
            this.chartSenalFiltrada.Titles.Add(title2);
            // 
            // BtnResetZoom
            // 
            this.BtnResetZoom.Location = new System.Drawing.Point(1179, 45);
            this.BtnResetZoom.Name = "BtnResetZoom";
            this.BtnResetZoom.Size = new System.Drawing.Size(71, 48);
            this.BtnResetZoom.TabIndex = 4;
            this.BtnResetZoom.Text = "Reset Zoom";
            this.BtnResetZoom.UseVisualStyleBackColor = true;
            this.BtnResetZoom.Click += new System.EventHandler(this.BtnResetZoom_Click);
            // 
            // FrmAplicarFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 605);
            this.Controls.Add(this.BtnResetZoom);
            this.Controls.Add(this.chartSenalFiltrada);
            this.Controls.Add(this.chartSenalOriginal);
            this.Name = "FrmAplicarFiltro";
            this.Text = "FrmAplicarFiltro";
            this.Load += new System.EventHandler(this.FrmAplicarFiltro_Load);
            this.Resize += new System.EventHandler(this.FrmAplicarFiltro_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSenalFiltrada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenalOriginal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSenalFiltrada;
        private System.Windows.Forms.Button BtnResetZoom;
    }
}