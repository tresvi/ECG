using ECGViewer.Modelos;
using FftSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer
{
    public partial class FrmConsolaFiltros : Form
    {
        public readonly List<Muestra> _senalOriginal;
        public readonly List<Muestra> _senalFiltrada;
        public readonly int _frecuenciaMuestreo;

        public FrmConsolaFiltros(List<Muestra> senal, int frecuenciaMuestreo)
        {
            InitializeComponent();
            _senalOriginal = senal;
            _senalFiltrada = Utiles.ClonarSenal(in _senalOriginal);
            _frecuenciaMuestreo = frecuenciaMuestreo;
        }


        private void Graficar(Chart chart, List<Muestra> senal)
        {
            ChartArea chartArea = chart.ChartAreas[0];

            //Autoescala en ejes
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.Minimum = 0;  // Autoajustar el mínimo
            chartArea.AxisX.Maximum = Double.NaN;  // Autoajustar el máximo
            chartArea.AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartArea.AxisY.Maximum = Double.NaN;  // Autoajustar el máximo
            chartArea.AxisY.Title = "Amplitud Vs Tiempo[seg]";
            chartArea.AxisX.Title = "";

            chart.Series["Muestras"].Points.Clear();

            foreach (var muestra in senal)
            {
                chart.Series["Muestras"].Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
            }
            chartArea.AxisX.LabelStyle.Format = "0.00";
        }


        private void FrmAplicarFiltro_Resize(object sender, EventArgs e)
        {
            const int MARGEN = 1;
            int mitadFormulario = this.Height / 2;
            //chartSenalOriginal.Top = gbButtons.Top  + gbButtons.Height + MARGEN;
            chartSenalOriginal.Height =  this.Height/2 - (gbButtons.Top + gbButtons.Height) + 10;
            chartSenalFiltrada.Top = chartSenalOriginal.Height + chartSenalOriginal.Top;
            chartSenalFiltrada.Height = chartSenalOriginal.Height;
        }


        private void FrmAplicarFiltro_Load(object sender, EventArgs e)
        {
            Graficar(chartSenalOriginal, _senalOriginal);
            Graficar(chartSenalFiltrada, _senalFiltrada);

            // Configura el gráfico
            chartSenalOriginal.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;  // Mostrar barra de desplazamiento
            chartSenalOriginal.ChartAreas[0].AxisX.ScrollBar.Size = 15;                  // Tamaño de la barra de desplazamiento

            // Define el tamaño de la vista y habilita el desplazamiento
            chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.Zoomable = true;       // Habilitar zoom
           // chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.Size = 50;           // Cantidad de puntos visibles inicialmente

            // Habilitar el desplazamiento
            chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.MinSize = 0.5;         // Mínima vista permitida (1 punto)
            chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.Position = 0;          // Posición inicial de la vista

            // Configura el comportamiento del scroll
            chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 5;       // Tamaño del desplazamiento pequeño (5 puntos)
            chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;    // Tamaño mínimo de desplazamiento

            // Opcional: Configurar los intervalos del eje X para hacer la navegación más clara
            chartSenalOriginal.ChartAreas[0].AxisX.Interval = 1;

            ActivarZoom(chartSenalOriginal, true);
        }


        public static void ActivarZoom(Chart chart, bool enable)
        {
            chart.ChartAreas[0].CursorX.IsUserEnabled = enable;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = enable;
            chart.ChartAreas[0].CursorX.Interval = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = enable;
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0;

            if (enable == false)
            {
                //Quita la linea de los cursores
                chart.ChartAreas[0].CursorX.SetCursorPosition(double.NaN);
                chart.ChartAreas[0].CursorY.SetCursorPosition(double.NaN);
            }
        }


        private void BtnResetZoom_Click(object sender, EventArgs e)
        {
            chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chartSenalFiltrada.ChartAreas[0].AxisX.Minimum = chartSenalOriginal.ChartAreas[0].AxisX.Minimum;
            chartSenalFiltrada.ChartAreas[0].AxisX.Maximum = chartSenalOriginal.ChartAreas[0].AxisX.Maximum;
        }


        private void chartSenalOriginal_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if (e.Axis.AxisName == AxisName.X)
            {
                chartSenalFiltrada.ChartAreas[0].AxisX.Minimum = e.Axis.ScaleView.ViewMinimum;
                chartSenalFiltrada.ChartAreas[0].AxisX.Maximum = e.Axis.ScaleView.ViewMaximum;
            }
        }


        private void BtnFiltroPasaBajo_Click(object sender, EventArgs e)
        {
            FrmPasaAltosBajos frmPasaBajos = new FrmPasaAltosBajos("Configuracion filtro Pasa Bajos", 49);
            if (frmPasaBajos.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.LowPass(senal, _frecuenciaMuestreo, maxFrequency: (double) frmPasaBajos.FrecuenciaCorte);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            //Por alguna razon, el valor automatico de los ejes se altera
            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = chartSenalOriginal.ChartAreas[0].AxisY.Minimum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = chartSenalOriginal.ChartAreas[0].AxisY.Maximum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = chartSenalOriginal.ChartAreas[0].AxisY.Interval;
        }


        private void BtnFiltroPasaAlto_Click(object sender, EventArgs e)
        {
            FrmPasaAltosBajos frmPAltos = new FrmPasaAltosBajos("Configuracion filtro Pasa Alto", 1);
            if (frmPAltos.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.HighPass(senal, _frecuenciaMuestreo, minFrequency: (double)frmPAltos.FrecuenciaCorte);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            //Por alguna razon, el valor automatico de los ejes se altera
            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = chartSenalOriginal.ChartAreas[0].AxisY.Minimum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = chartSenalOriginal.ChartAreas[0].AxisY.Maximum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = chartSenalOriginal.ChartAreas[0].AxisY.Interval;
        }


        private void BtnFiltroPasaBanda_Click(object sender, EventArgs e)
        {
            FrmPasaEliminaBanda frmPBanda = new FrmPasaEliminaBanda("Configuracion filtro Pasa Banda", 1 ,  49);
            if (frmPBanda.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.BandPass(senal, _frecuenciaMuestreo, (double)frmPBanda.FrecuenciaCorteMin, (double) frmPBanda.FrecuenciaCorteMax);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            //Por alguna razon, el valor automatico de los ejes se altera
            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = chartSenalOriginal.ChartAreas[0].AxisY.Minimum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = chartSenalOriginal.ChartAreas[0].AxisY.Maximum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = chartSenalOriginal.ChartAreas[0].AxisY.Interval;
        }


        private void BtnFiltroNotch_Click(object sender, EventArgs e)
        {
            FrmPasaEliminaBanda frmEBanda = new FrmPasaEliminaBanda("Configuracion filtro Elimina Banda", 49.5M, 50.5M);
            if (frmEBanda.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.BandStop(senal, _frecuenciaMuestreo, (double)frmEBanda.FrecuenciaCorteMin, (double)frmEBanda.FrecuenciaCorteMax);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            //Por alguna razon, el valor automatico de los ejes se altera
            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = chartSenalOriginal.ChartAreas[0].AxisY.Minimum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = chartSenalOriginal.ChartAreas[0].AxisY.Maximum;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = chartSenalOriginal.ChartAreas[0].AxisY.Interval;
        }
    }
}
