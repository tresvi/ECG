using ECGViewer.Formularios;
using ECGViewer.Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECGViewer
{
    internal static class GraphicHelpers
    {
        /*
                     //Creo la nueva serie de datos.
            _graphSerie = new Series("Muestras");
            _graphSerie.Color = System.Drawing.Color.AliceBlue;
            _graphSerie.ChartType = SeriesChartType.Line;
            _graphSerie.BorderWidth = 1; //2;
            _graphSerie.XValueType = ChartValueType.Single;
            _graphSerie.YValueType = ChartValueType.Single;
                    //chartEspectro.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chartEspectro.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
         */


        internal static void InicializarGrafico(Chart chart)
        {
            // Configura el gráfico
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;  // Mostrar barra de desplazamiento
            chart.ChartAreas[0].AxisX.ScrollBar.Size = 15;                  // Tamaño de la barra de desplazamiento

            // Define el tamaño de la vista y habilita el desplazamiento
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;             // Habilitar zoom
            //chart.ChartAreas[0].AxisX.ScaleView.Size = 50;                 // Cantidad de puntos visibles inicialmente

            // Habilitar el desplazamiento
            chart.ChartAreas[0].AxisX.ScaleView.MinSize = 1;                 // Mínima vista permitida (1 punto)
            chart.ChartAreas[0].AxisX.ScaleView.Position = 0;                // Posición inicial de la vista

            // Configura el comportamiento del scroll
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 5;         // Tamaño del desplazamiento pequeño (5 puntos)
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;      // Tamaño mínimo de desplazamiento

            // Opcional: Configurar los intervalos del eje X para hacer la navegación más clara
            chart.ChartAreas[0].AxisX.Interval = 0.5;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            ActivarZoom(chart, true);
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


        internal static void ResetZoom(Chart chart)
        {
            //double maximo = this.chartEspectro.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            //chartEspectro.ChartAreas[0].AxisX.Interval = (int) maximo / 10;
            //ChartUtils.InicializarChart(chartEspectro);
            chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }


        internal static void CargarGrafico(Chart chart, in List<Muestra> senal)
        {
            //Creo la nueva serie de datos.
            /*
            Series serie = new Series();
            serie = new Series("Muestras");
            serie.Color = System.Drawing.Color.AliceBlue;
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 1; //2;
            serie.XValueType = ChartValueType.Single;
            serie.YValueType = ChartValueType. Single;
            */
            ChartArea chartArea = chart.ChartAreas[0];

            Series series = chart.Series["Muestras"];

            series.Points.Clear();
            foreach (var muestra in senal)
            {
                series.Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
            }

            chart.ChartAreas[0].AxisX.Interval = 0.5;  // Intervalo de labels en X
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            //Autoescalas
            chart.ChartAreas[0].AxisX.Minimum = Double.NaN;
            chart.ChartAreas[0].AxisX.Maximum = Double.NaN;
            chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = Double.NaN;
        }

    }
}
