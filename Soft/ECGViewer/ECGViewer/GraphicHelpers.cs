using ECGViewer.Formularios;
using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ECGViewer.Properties;

namespace ECGViewer
{
    internal static class GraphicHelpers
    {

        internal static void InicializarGrafico(Chart chart)
        {
            ChartArea chartArea = chart.ChartAreas[0];

            // Configura el gráfico
            chartArea.AxisX.ScrollBar.Size = 15;                  // Tamaño de la barra de desplazamiento
            chartArea.AxisX.ScrollBar.IsPositionedInside = true;  // Mostrar barra de desplazamiento

            // Define el tamaño de la vista y habilita el desplazamiento
            chartArea.AxisX.ScaleView.Zoomable = true;             // Habilitar zoom
            //chartArea.AxisX.ScaleView.Size = 50;                 // Cantidad de puntos visibles inicialmente

            // Habilitar el desplazamiento
            chartArea.AxisX.ScaleView.MinSize = 0.5;                 // Mínima vista permitida (1 punto)
            chartArea.AxisX.ScaleView.Position = 0;                // Posición inicial de la vista

            // Configura el comportamiento del scroll
            chartArea.AxisX.ScaleView.SmallScrollSize = 5;         // Tamaño del desplazamiento pequeño (5 puntos)
            chartArea.AxisX.ScaleView.SmallScrollMinSize = 1;      // Tamaño mínimo de desplazamiento

            // Opcional: Configurar los intervalos del eje X para hacer la navegación más clara
            chartArea.AxisX.Interval = 0.5;
            chartArea.AxisX.LabelStyle.Format = "0.00";

            //Autoescalas
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = Double.NaN;
            chartArea.AxisY.Minimum = Double.NaN;
            chartArea.AxisY.Maximum = Double.NaN;

            // Configurar las líneas de cursor
            chartArea.CursorX.LineColor = System.Drawing.Color.Red;
            chartArea.CursorX.LineWidth = 2; // Cambia el grosor aquí
            chartArea.CursorY.LineColor = System.Drawing.Color.Red;
            chartArea.CursorY.LineWidth = 2; // Cambia el grosor aquí

            chart.PostPaint += chartSenal_PostPaint;

            ActivarZoom(chart, true);
        }

        static private void chartSenal_PostPaint(object sender, ChartPaintEventArgs e)
        {
            // Detener el cronómetro después de que el gráfico se haya dibujado
            _stopwatch.Stop();
            
            // Mostrar el tiempo en milisegundos
            Debug.WriteLine("T: " + _stopwatch.ElapsedMilliseconds + " - " + DateTime.Now.ToString("ss.fff"));
            _contadorImpresion = 0;
        }


        internal static void ActivarZoom(Chart chart, bool enable)
        {
            chart.ChartAreas[0].CursorX.IsUserEnabled = enable;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = enable;
            chart.ChartAreas[0].CursorX.Interval = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = enable;
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0;

            chart.ChartAreas[0].CursorY.Interval = 0;

            if (enable == false)
            {
                //Quita la linea de los cursores
                chart.ChartAreas[0].CursorX.SetCursorPosition(double.NaN);
                chart.ChartAreas[0].CursorY.SetCursorPosition(double.NaN);
            }
        }


        internal static void InsertarMarcador(Chart chart, double posicionX, double posicionY)
        {
            double xValue, yValue = 0;
            ChartArea chartArea = chart.ChartAreas[0];
            xValue = chartArea.AxisX.PixelPositionToValue(posicionX);
            yValue = chartArea.AxisY.PixelPositionToValue(posicionY);

            StripLineWithComment stripLine = new StripLineWithComment(xValue, yValue, "", 12, 10);
            chart.ChartAreas[0].AxisX.StripLines.Add(stripLine);

            FrmEditorTextoMarcadores frmEditorTextoMarcadores = new FrmEditorTextoMarcadores();
            frmEditorTextoMarcadores.ShowDialog();
            if (frmEditorTextoMarcadores.DialogResult == DialogResult.Cancel)
            {
                chart.ChartAreas[0].AxisX.StripLines.Remove(stripLine);
                return;
            }

            stripLine.Descripcion = frmEditorTextoMarcadores.MarcadorDescripcion;
            stripLine.Annotation.AnchorDataPoint = chart.Series[0].Points.FindMaxByValue();//.FindByValue(30, "Y");
            chart.Annotations.Add(stripLine.Annotation);
        }


        internal static void ResetZoom(Chart chart, List<Muestra> senal)
        {
            chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            //chart.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }


        internal static void CargarGrafico(Chart chart, in List<Muestra> senal,  bool usarAutoescala)
        {
            ChartArea chartArea = chart.ChartAreas[0];
            Series serie = chart.Series["Muestras"];
            //serie.Color = Color.Red;

            chartArea.AxisX.StripLines.Clear();
            chart.Annotations.Clear();
            serie.Points.Clear();

            foreach (var muestra in senal)
            {
                serie.Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
            }

            chart.ChartAreas[0].AxisX.Interval = 0.5;  // Intervalo de labels en X
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            //Autoescalas
            chart.ChartAreas[0].AxisX.Minimum = 0;
            if (usarAutoescala)
            {
                chart.ChartAreas[0].AxisX.Maximum = Double.NaN;
                chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
                chart.ChartAreas[0].AxisY.Maximum = Double.NaN;
            }
        }


        public static void CargarAnotaciones(Chart chart, in List<StripLineWithComment> anotaciones)
        {
            foreach (StripLineWithComment anotacion in anotaciones)
            {
                chart.ChartAreas[0].AxisX.StripLines.Add(anotacion);
                anotacion.Annotation.AnchorDataPoint = chart.Series[0].Points.FindMaxByValue();//.FindByValue(30, "Y");
                chart.Annotations.Add(anotacion.Annotation);
            }
        }


        static Stopwatch _stopwatch = new Stopwatch();
        static int _contadorImpresion = 0;
        internal static void ActualizarGrafico(Chart chart, in List<Muestra> senal, int nroMuestrasPorPantalla)
        {
            ChartArea chartArea = chart.ChartAreas[0];
            _contadorImpresion++;
            Series serie = chart.Series["Muestras"];
            //serie.Color = Color.Red;
            
            int inicioGrafico = senal.Count - nroMuestrasPorPantalla;
            inicioGrafico = inicioGrafico < 0 ? 0 : inicioGrafico;
            
            chart.SuspendLayout();

            serie.Points.Clear();

            for (int i = inicioGrafico; i < senal.Count -1; i++) 
            {
                Muestra muestra = senal[i];
                serie.Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
            }

            _stopwatch.Restart();
            chart.ResumeLayout();
            chart.Invalidate();
            //Debug.WriteLine($"Tiempo de graficado: {sw.ElapsedMilliseconds}");
            /*
            chart.ChartAreas[0].AxisX.Interval = 0.5;  // Intervalo de labels en X
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            //Autoescalas
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = Double.NaN;
            chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = Double.NaN;
            */
        }


        internal static void ModoECG(Chart chart, bool activar)
        {
            if (activar)
            {
                //!!
                // Configuración del eje X del chart
                chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2;  // Línea de la cuadrícula mayor
                chart.ChartAreas[0].AxisX.MinorGrid.LineWidth = 1;  // Línea de la cuadrícula menor

                // Subdivisiones mayores (cada 0.2 segundos)
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.2;
                chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.2;
                chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Solid;

                // Subdivisiones menores (cada 0.04 segundos)
                chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
                chart.ChartAreas[0].AxisX.MinorTickMark.Interval = 0.04;
                chart.ChartAreas[0].AxisX.MinorGrid.Interval = 0.04;
                chart.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
                chart.ChartAreas[0].AxisX.MinorGrid.LineWidth = 1;

                chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
                chart.ChartAreas[0].AxisY.MinorGrid.Interval = 0.1;
                chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.5;
                chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.5;
                chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 2;  // Línea de la cuadrícula mayor

            }
            else
            {
                chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.5;
                chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;

                // Subdivisiones mayores (cada 1 segundo)
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
                chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.5;
                chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;
                chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
            }
        }

    }
}
