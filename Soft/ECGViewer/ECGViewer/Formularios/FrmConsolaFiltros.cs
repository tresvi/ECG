using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ECGViewer
{
    public partial class FrmConsolaFiltros : Form
    {
        public readonly List<(double, double)> _senal;
        public readonly List<(double, double)> _senalFiltrada;

        public FrmConsolaFiltros(List<(double, double)> senal)
        {
            InitializeComponent();
            _senal = senal;
            _senalFiltrada = _senal;
        }


        private void Graficar(Chart chart, List<(double, double)> senal)
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

            foreach (var (x, y) in senal)
            {
                chart.Series["Muestras"].Points.AddXY(x, -1 * y);
            }
            chartArea.AxisX.LabelStyle.Format = "0.00";
        }


        private void FrmAplicarFiltro_Resize(object sender, EventArgs e)
        {
            int mitadFormulario = this.Height / 2;
            chartSenalOriginal.Height = mitadFormulario - 50;
            chartSenalFiltrada.Top = mitadFormulario ;
            chartSenalFiltrada.Height = mitadFormulario - 50;
        }


        private void FrmAplicarFiltro_Load(object sender, EventArgs e)
        {
            Graficar(chartSenalOriginal, _senal);
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
            FrmPasaAltosBajos frmPasaAltosBajos = new FrmPasaAltosBajos("Configuracion filtro Pasa Bajos", 49);

            if (frmPasaAltosBajos.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Frecuencia elegida: {frmPasaAltosBajos.FrecuenciaCorte}");
            }
        }
    }
}
