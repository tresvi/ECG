using ECGViewer.Modelos;
using FftSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer
{
    public partial class FrmConsolaFiltros : Form
    {
        public List<Muestra> SenalFiltrada { get; private set; }
        public readonly List<Muestra> _senalOriginal;
        public readonly List<Muestra> _senalFiltrada;
        public readonly int _frecuenciaMuestreo;

        public double _yMinSenal, _yMaxSenal, _yIntervalSenal;
        public double _yMinEspectro, _yMaxEspectro, _yIntervalEspectro;
        
        
        public FrmConsolaFiltros(in List<Muestra> senal, int frecuenciaMuestreo)
        {
            InitializeComponent();
            _senalOriginal = senal;
            _senalFiltrada = Utiles.ClonarSenal(in _senalOriginal);
            _frecuenciaMuestreo = frecuenciaMuestreo;

            chartSenalOriginal.PostPaint += chartSenalOriginal_PostPaint;
        }

        /// <summary>
        /// Captura todos los Maximos, minimos e Intervalos del grafico de la senal original
        /// para que luego puedan ser aplicados al de la senal filtrada. De esta manera la 
        /// visualizacion y escalas de ambos graficos será identica (si no, la autoescala en Y del
        /// graf. de filtrada, estorba al cambiar escalas)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartSenalOriginal_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is ChartArea)
            {
                _yMinEspectro = chartSenalOriginal.ChartAreas[1].AxisY.Minimum;
                _yMaxEspectro = chartSenalOriginal.ChartAreas[1].AxisY.Maximum;
                int cantidadLineas = chartSenalOriginal.ChartAreas[1].AxisY.CustomLabels.Count;

                if (cantidadLineas - 1 != 0)
                    _yIntervalEspectro = (_yMaxEspectro - _yMinEspectro) / (cantidadLineas - 1);

                _yMinSenal = chartSenalOriginal.ChartAreas[0].AxisY.Minimum;
                _yMaxSenal = chartSenalOriginal.ChartAreas[0].AxisY.Maximum;
                cantidadLineas = chartSenalOriginal.ChartAreas[0].AxisY.CustomLabels.Count;

                if (cantidadLineas - 1 != 0)
                    _yIntervalSenal = (_yMaxSenal - _yMinSenal) / (cantidadLineas - 1);
            }
        }


        private void InicializarGraficos()
        {
            ChartArea caSenalOriginal = chartSenalOriginal.ChartAreas[0];
            caSenalOriginal.AxisX.Interval = 0.5;
            caSenalOriginal.AxisX.Minimum = 0;  // Autoajustar el mínimo
            caSenalOriginal.AxisX.Maximum = Double.NaN;  // Autoajustar el máximo
            caSenalOriginal.AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            caSenalOriginal.AxisY.Maximum = Double.NaN;  // Autoajustar el máximo
            caSenalOriginal.AxisY.Title = "Amplitud Vs Tiempo[seg]";
            caSenalOriginal.AxisX.Title = "";
            caSenalOriginal.AxisX.LabelStyle.Format = "0.00";

            ChartArea caEspectroOriginal = chartSenalOriginal.ChartAreas[1];
            caEspectroOriginal.AxisX.Interval = 2;
            caEspectroOriginal.AxisX.LabelStyle.Format = "0.0";
            caEspectroOriginal.AxisX.Minimum = 0;
            caEspectroOriginal.AxisX.Maximum = 100;
            caEspectroOriginal.AxisY.Minimum = 0;
            caEspectroOriginal.AxisY.Maximum = Double.NaN;

            //La config del grafico de filtrada, se toma del de senal original
            ChartArea caSenalFiltrada = chartSenalFiltrada.ChartAreas[0];
            caSenalFiltrada.AxisX.Interval = caSenalOriginal.AxisX.Interval;
            caSenalFiltrada.AxisX.Minimum = caSenalOriginal.AxisX.Minimum;
            caSenalFiltrada.AxisX.Maximum = caSenalOriginal.AxisX.Maximum;
            caSenalFiltrada.AxisY.Interval = caSenalOriginal.AxisY.Interval;
            caSenalFiltrada.AxisY.Minimum = caSenalOriginal.AxisY.Minimum;
            caSenalFiltrada.AxisY.Maximum = caSenalOriginal.AxisY.Maximum;
            caSenalFiltrada.AxisY.Title = caSenalOriginal.AxisY.Title;
            caSenalFiltrada.AxisX.Title = caSenalOriginal.AxisX.Title;
            caSenalFiltrada.AxisX.LabelStyle.Format = caSenalOriginal.AxisX.LabelStyle.Format;

            ChartArea caEspectroFiltrada = chartSenalFiltrada.ChartAreas[1];
            caEspectroFiltrada.AxisX.Interval = caEspectroOriginal.AxisX.Interval;
            caEspectroFiltrada.AxisX.Minimum = caEspectroOriginal.AxisX.Minimum;
            caEspectroFiltrada.AxisX.Maximum = caEspectroOriginal.AxisX.Maximum;
            caEspectroFiltrada.AxisY.Interval = caEspectroOriginal.AxisY.Interval;
            caEspectroFiltrada.AxisY.Minimum = caEspectroOriginal.AxisY.Minimum;
            caEspectroFiltrada.AxisY.Maximum = caEspectroOriginal.AxisY.Maximum;
            caEspectroFiltrada.AxisY.Title = caEspectroOriginal.AxisY.Title;
            caEspectroFiltrada.AxisX.Title = caEspectroOriginal.AxisX.Title;
            caEspectroFiltrada.AxisX.LabelStyle.Format = caEspectroOriginal.AxisX.LabelStyle.Format;
        }


        private void Graficar(Chart chart, List<Muestra> senal)
        {
            chart.Series["Muestras"].Points.Clear();

            foreach (var muestra in senal)
            {
                chart.Series["Muestras"].Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
            }
        }


        private void FrmAplicarFiltro_Resize(object sender, EventArgs e)
        {
            const int MARGEN = 1;
            int mitadFormulario = this.Height / 2;
            //chartSenalOriginal.Top = gbButtons.Top  + gbButtons.Height + MARGEN;
            chartSenalOriginal.Height =  this.Height/2 - (toolStrip1.Top + toolStrip1.Height) + 10;
            chartSenalFiltrada.Top = chartSenalOriginal.Height + chartSenalOriginal.Top;
            chartSenalFiltrada.Height = chartSenalOriginal.Height;
        }


        private void FrmAplicarFiltro_Load(object sender, EventArgs e)
        {
            Graficar(chartSenalOriginal, _senalOriginal);
            Graficar(chartSenalFiltrada, _senalFiltrada);
            InicializarGraficos();

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
            chartSenalOriginal.ChartAreas[0].AxisX.Interval = 0.5;

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


        private void chartSenalOriginal_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if (e.Axis.AxisName == AxisName.X)
            {
                chartSenalFiltrada.ChartAreas[0].AxisX.Minimum = e.Axis.ScaleView.ViewMinimum;
                chartSenalFiltrada.ChartAreas[0].AxisX.Maximum = e.Axis.ScaleView.ViewMaximum;
            }
        }


        private void tsbResetZoom_Click(object sender, EventArgs e)
        {
            chartSenalOriginal.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chartSenalFiltrada.ChartAreas[0].AxisX.Minimum = chartSenalOriginal.ChartAreas[0].AxisX.Minimum;
            chartSenalFiltrada.ChartAreas[0].AxisX.Maximum = chartSenalOriginal.ChartAreas[0].AxisX.Maximum;
        }


        private void tsbPasaBajo_Click(object sender, EventArgs e)
        {
            FrmPasaAltosBajos frmPasaBajos = new FrmPasaAltosBajos("Configuracion filtro Pasa Bajos", 49);
            if (frmPasaBajos.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.LowPass(senal, _frecuenciaMuestreo, maxFrequency: (double)frmPasaBajos.FrecuenciaCorte);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = _yMinSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = _yMaxSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = _yIntervalSenal;
        }


        private void tsbPasaAlto_Click(object sender, EventArgs e)
        {
            FrmPasaAltosBajos frmPAltos = new FrmPasaAltosBajos("Configuracion filtro Pasa Alto", 0.8m);
            if (frmPAltos.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.HighPass(senal, _frecuenciaMuestreo, minFrequency: (double)frmPAltos.FrecuenciaCorte);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = _yMinSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = _yMaxSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = _yIntervalSenal;
        }


        private void tsbPasaBanda_Click(object sender, EventArgs e)
        {
            FrmPasaEliminaBanda frmPBanda = new FrmPasaEliminaBanda("Configuracion filtro Pasa Banda", 0.8m, 49);
            if (frmPBanda.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.BandPass(senal, _frecuenciaMuestreo, (double)frmPBanda.FrecuenciaCorteMin, (double)frmPBanda.FrecuenciaCorteMax);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = _yMinSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = _yMaxSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = _yIntervalSenal;
        }


        private void tsbNotch_Click(object sender, EventArgs e)
        {
            FrmPasaEliminaBanda frmEBanda = new FrmPasaEliminaBanda("Configuracion filtro Elimina Banda", 49.5M, 50.5M);
            if (frmEBanda.ShowDialog() != DialogResult.OK) return;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalFiltrada);
            double[] filtered = Filter.BandStop(senal, _frecuenciaMuestreo, (double)frmEBanda.FrecuenciaCorteMin, (double)frmEBanda.FrecuenciaCorteMax);

            for (int i = 0; i < _senalFiltrada.Count; i++)
                _senalFiltrada[i].Canal[0] = filtered[i];

            Graficar(chartSenalFiltrada, _senalFiltrada);

            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = _yMinSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = _yMaxSenal;
            chartSenalFiltrada.ChartAreas[0].AxisY.Interval = _yIntervalSenal;
        }


        private void tgbTipoVista_CheckedChanged(object sender, EventArgs e)
        {
            /********** TODO: Sacar esto. Poner que el filtro pueda ser aplicado con cualquier vista ********/
            tsbResetZoom.Enabled = !tgbTipoVista.Checked;
            tsbPasaBajo.Enabled = !tgbTipoVista.Checked;
            tsbPasaAlto.Enabled = !tgbTipoVista.Checked;
            tsbPasaBanda.Enabled = !tgbTipoVista.Checked;
            tsbNotch.Enabled = !tgbTipoVista.Checked;
            /*****************************************************************************************/

            Series serieEspectro = chartSenalOriginal.Series["Espectro"];
            ChartArea chartArea = chartSenalOriginal.ChartAreas[0];
            ChartArea chartAreaEspectro = chartSenalOriginal.ChartAreas[1];

            Series serieEspectroFiltrada = chartSenalFiltrada.Series["Espectro"];
            ChartArea chartAreaFiltrada = chartSenalFiltrada.ChartAreas[0];
            ChartArea chartAreaEspectroFiltrada = chartSenalFiltrada.ChartAreas[1];

            //serieMuestras.ChartArea = chartArea.Name;
            serieEspectro.ChartArea = chartAreaEspectro.Name;
            chartArea.Visible = !tgbTipoVista.Checked;
            chartAreaEspectro.Visible = tgbTipoVista.Checked;

            serieEspectroFiltrada.ChartArea = chartAreaEspectroFiltrada.Name;
            chartAreaFiltrada.Visible = !tgbTipoVista.Checked;
            chartAreaEspectroFiltrada.Visible = tgbTipoVista.Checked;

            if (tgbTipoVista.Checked)
            {
                /************* senalOriginal****************/
                double[] signal = Utiles.ClonarVectorParaFFT(_senalOriginal);

                System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(signal);
                double[] psd = FftSharp.FFT.Magnitude(spectrum);
                double[] freq = FftSharp.FFT.FrequencyScale(psd.Length, _frecuenciaMuestreo);

                serieEspectro.Points.Clear();
                for (int i = 0; i < psd.Count(); i++)
                {
                    serieEspectro.Points.AddXY(freq[i], psd[i]);
                }


                /************* senalFiltrada****************/
                signal = Utiles.ClonarVectorParaFFT(_senalFiltrada);

                System.Numerics.Complex[] spectrumFiltrado = FftSharp.FFT.Forward(signal);
                psd = FftSharp.FFT.Magnitude(spectrumFiltrado);
                freq = FftSharp.FFT.FrequencyScale(psd.Length, _frecuenciaMuestreo);

                serieEspectroFiltrada.Points.Clear();
                for (int i = 0; i < psd.Count(); i++)
                {
                    serieEspectroFiltrada.Points.AddXY(freq[i], psd[i]);
                }

                chartAreaEspectroFiltrada.AxisY.Minimum = _yMinEspectro;
                chartAreaEspectroFiltrada.AxisY.Maximum = _yMaxEspectro;
                chartAreaEspectroFiltrada.AxisY.Interval = _yIntervalEspectro;
                chartAreaEspectroFiltrada.AxisY.RoundAxisValues();
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmConsolaFiltros_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tsbAceptar_Click(object sender, EventArgs e)
        {
            SenalFiltrada = _senalFiltrada;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
