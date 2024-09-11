using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//TODO: Agregar captura en vivo desde puerto serie
//TODO: Agregar sistema de marcas
//TODO: Agregar guardado de archivo
//TODO: Agregar exportacion a CSV y tabla C++

//https://stackoverflow.com/questions/25801257/c-sharp-line-chart-how-to-create-vertical-line

namespace ECGViewer
{
    public partial class Form1 : Form
    {
        Series _graphSerie;
        private Panel chartPanel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configura el gráfico
            chartSenal.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;  // Mostrar barra de desplazamiento
            chartSenal.ChartAreas[0].AxisX.ScrollBar.Size = 15;                  // Tamaño de la barra de desplazamiento

            // Define el tamaño de la vista y habilita el desplazamiento
            chartSenal.ChartAreas[0].AxisX.ScaleView.Zoomable = true;             // Habilitar zoom
            chartSenal.ChartAreas[0].AxisX.ScaleView.Size = 50;                   // Cantidad de puntos visibles inicialmente

            // Habilitar el desplazamiento
            chartSenal.ChartAreas[0].AxisX.ScaleView.MinSize = 1;                 // Mínima vista permitida (1 punto)
            chartSenal.ChartAreas[0].AxisX.ScaleView.Position = 0;                // Posición inicial de la vista

            // Configura el comportamiento del scroll
            chartSenal.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 5;         // Tamaño del desplazamiento pequeño (5 puntos)
            chartSenal.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;      // Tamaño mínimo de desplazamiento

            // Opcional: Configurar los intervalos del eje X para hacer la navegación más clara
            chartSenal.ChartAreas[0].AxisX.Interval = 1;

            ActivarZoom(chartSenal, true);




        }


        static List<(double, double)> LoadCsvData(string filePath)
        {
            var dataList = new List<(double, double)>();

            // Verifica si el archivo existe
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("El archivo CSV no se encontró.", filePath);
            }

            // Lee el archivo línea por línea
            foreach (var line in File.ReadLines(filePath))
            {
                // Divide la línea en partes usando la coma como delimitador
                var parts = line.Split('\t');

                if (parts.Length >= 2)
                {
                    // Convierte las partes a float y añade a la lista
                    if (double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double value1) &&
                        double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double value2))
                    {
                        dataList.Add((value1, value2));
                    }
                    else
                    {
                        Console.WriteLine($"No se pudieron convertir los valores: {line}");
                    }
                }
                else
                {
                    Console.WriteLine($"Línea con formato incorrecto: {line}");
                }
            }

            return dataList;
        }



        public static void ActivarZoom(Chart chart, bool enable)
        {
            chart.ChartAreas[0].CursorX.IsUserEnabled = enable;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = enable;
            chart.ChartAreas[0].CursorX.Interval = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = enable;
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0;

            //chart.ChartAreas[0].CursorY.IsUserEnabled = enable;
            //chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = enable;
            //chart.ChartAreas[0].CursorY.Interval = 0;
            //chart.ChartAreas[0].AxisY.ScaleView.Zoomable = enable;
            //chart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            //chart.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            //chart.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 0;
            if (enable == false)
            {
                //Quita la linea de los cursores
                chart.ChartAreas[0].CursorX.SetCursorPosition(double.NaN);
                chart.ChartAreas[0].CursorY.SetCursorPosition(double.NaN);
            }
        }

        private void BtnResetZoom_Click(object sender, EventArgs e)
        {
            //double maximo = this.chartEspectro.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            //chartEspectro.ChartAreas[0].AxisX.Interval = (int) maximo / 10;
            //ChartUtils.InicializarChart(chartEspectro);
            this.chartSenal.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            this.chartSenal.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);

        }

        private void BtnMarcadores_Click(object sender, EventArgs e)
        {

            //Marca los puntos del grafico. Todos
            // Configurar estilo del marcador
            //chartEspectro.Series[0].MarkerStyle = MarkerStyle.Circle;  // Estilo de marcador (ej. círculo)
            //chartEspectro.Series[0].MarkerSize = 10;                   // Tamaño del marcador
            //chartEspectro.Series[0].MarkerColor = Color.Red;           // Color del marcador

            // Crear una línea vertical en el gráfico
            //VerticalLineAnnotation annotation = new VerticalLineAnnotation();
            //annotation.AxisX = chartEspectro.ChartAreas[0].AxisX;
            //annotation.AxisY = chartEspectro.ChartAreas[0].AxisY;
            //annotation.X = 2;  // Posición en el eje X
            //annotation.LineColor = Color.Blue;
            //annotation.LineWidth = 2;

            //// Agregar la anotación al gráfico
            //chartEspectro.Annotations.Add(annotation);


            //// Crear una anotación de texto
            // Crear una anotación de texto en el punto (X=3, Y=30)
            TextAnnotation textAnnotation = new TextAnnotation();
            textAnnotation.Text = "Marca en (3, 30)";
            textAnnotation.X = 3;   // Posición en el eje X
            textAnnotation.Y =0.23;  // Posición en el eje Y
            textAnnotation.Font = new Font("Arial", 10, FontStyle.Bold);
            textAnnotation.ForeColor = Color.Blue;

            // Colocar la anotación en la ubicación correcta
            textAnnotation.AnchorX = 3;
            textAnnotation.AnchorY = 0.33;
            textAnnotation.AnchorDataPoint = chartSenal.Series[0].Points.FindMaxByValue();//.FindByValue(30, "Y");  // Anclar a un punto específico

            // Agregar la anotación al gráfico
            chartSenal.Annotations.Add(textAnnotation);

            // Agregar un marcador en el punto específico (X=3, Y=30)
            DataPoint markerPoint = new DataPoint(3, 0.24);
            markerPoint.MarkerStyle = MarkerStyle.Star4;  // Estilo del marcador (ej. estrella)
            markerPoint.MarkerSize = 10;                 // Tamaño del marcador
            markerPoint.MarkerColor = Color.Red;         // Color del marcador

            // Agregar el marcador a la serie
            chartSenal.Series[0].Points.Add(markerPoint);
        }

        private void BtnLineaReferencia_Click(object sender, EventArgs e)
        {
            // Crear una línea horizontal en el eje Y
            StripLine stripLine = new StripLine();
            stripLine.IntervalOffset = 0.2;  // Valor en el eje Y donde se dibujará la línea
            stripLine.BorderColor = Color.Red;
            stripLine.BorderWidth = 2;
            stripLine.BorderDashStyle = ChartDashStyle.Dash;

            // Agregar la línea de referencia al eje Y
            chartSenal.ChartAreas[0].AxisY.StripLines.Add(stripLine);
            chartSenal.ChartAreas[0].AxisX.StripLines.Add(stripLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una nueva serie para los puntos aislados
            Series isolatedPointsSeries = new Series("Puntos Aislados");
            isolatedPointsSeries.ChartType = SeriesChartType.Point;  // Tipo de gráfico: puntos
            isolatedPointsSeries.MarkerStyle = MarkerStyle.Circle;   // Estilo de los marcadores
            isolatedPointsSeries.MarkerSize = 8;                    // Tamaño de los marcadores
            isolatedPointsSeries.Color = Color.Red;                 // Color de los puntos

            // Agregar puntos aislados
            isolatedPointsSeries.Points.AddXY(2, 10);  // Punto aislado en (X=2, Y=10)
            isolatedPointsSeries.Points.AddXY(5, 15);  // Punto aislado en (X=5, Y=15)
            isolatedPointsSeries.Points.AddXY(7, 5);   // Punto aislado en (X=7, Y=5)

            // Agregar la serie al gráfico
            chartSenal.Series.Add(isolatedPointsSeries);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Crear una línea vertical en el punto X=3
            VerticalLineAnnotation verticalLine = new VerticalLineAnnotation();
            verticalLine.AxisX = chartSenal.ChartAreas[0].AxisX;
            verticalLine.AxisY = chartSenal.ChartAreas[0].AxisY;
            verticalLine.X = 3;  // Posición en el eje X
            verticalLine.LineColor = Color.Green;
            verticalLine.LineWidth = 2;
            verticalLine.LineDashStyle = ChartDashStyle.Dash;

            // Agregar la línea vertical al gráfico
            chartSenal.Annotations.Add(verticalLine);

            // Agregar un marcador en la intersección de la línea vertical y el eje Y
            Series markerSeries = new Series("Marcador");
            markerSeries.ChartType = SeriesChartType.Point;
            markerSeries.MarkerStyle = MarkerStyle.Circle;   // Estilo del marcador
            markerSeries.MarkerSize = 10;                    // Tamaño del marcador
            markerSeries.MarkerColor = Color.Red;            // Color del marcador

            // Agregar el marcador en la posición X=3, Y=25 (por ejemplo)
            markerSeries.Points.AddXY(2.5, 0.3);

            // Agregar la serie con el marcador al gráfico
            chartSenal.Series.Add(markerSeries);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Crear una línea vertical que sea interactiva
            VerticalLineAnnotation interactiveLine = new VerticalLineAnnotation();
            interactiveLine.AxisX = chartSenal.ChartAreas[0].AxisX;
            interactiveLine.AxisY = chartSenal.ChartAreas[0].AxisY;
            interactiveLine.X = 3;  // Posición en el eje X
            interactiveLine.LineColor = Color.Blue;
            interactiveLine.LineWidth = 2;
            interactiveLine.LineDashStyle = ChartDashStyle.Solid;
            interactiveLine.ToolTip = "Haz clic en esta línea";  // Mostrar un tooltip al pasar el mouse

            //// Agregar un evento para capturar clics
            //interactiveLine.Click += (sender, e) => {
            //    MessageBox.Show("¡Hiciste clic en la línea!");
            //};

            // Agregar la anotación al gráfico
            chartSenal.Annotations.Add(interactiveLine);

        }

        private void chartEspectro_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void chartEspectro_MouseClick(object sender, MouseEventArgs e)
        {
            // Convertir las coordenadas del clic del mouse a elementos del gráfico
            HitTestResult result = chartSenal.HitTest(e.X, e.Y);

            // Verificar si el clic fue en un punto de la serie
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // Obtener el punto que fue tocado
                DataPoint clickedPoint = _graphSerie.Points[result.PointIndex];

                // Mostrar un mensaje con la información del punto
                MessageBox.Show($"¡Hiciste clic en el punto (X={clickedPoint.XValue}, Y={clickedPoint.YValues[0]})!");
            }
        }


        List<(double, double)> _senalECG;
        private void BtnCargarSenal_Click(object sender, EventArgs e)
        {
            string filePath = @"..\..\CSV\ECG_20Seg_NOFiltrado.txt"; // Ruta al archivo CSV
            _senalECG = LoadCsvData(filePath);

            //Creo la nueva serie de datos.
            _graphSerie = new Series("Muestras");
            _graphSerie.Color = System.Drawing.Color.Green;
            _graphSerie.ChartType = SeriesChartType.Line;  //SeriesChartType.Column; //SeriesChartType.Line;
            _graphSerie.BorderWidth = 1; //2;
            _graphSerie.XValueType = ChartValueType.Single;
            _graphSerie.YValueType = ChartValueType.Single;
            //chartEspectro.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chartEspectro.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            ChartArea chartArea = chartSenal.ChartAreas[0];

            // Configura los valores mínimo y máximo del eje Y
            chartArea.AxisY.Minimum = -0.12;
            chartArea.AxisY.Maximum = 0.5;

            Series series = chartSenal.Series["Muestras"];

            foreach (var (x, y) in _senalECG)
            {
                series.Points.AddXY(x, -1 * y);
            }
            _graphSerie = series;

            chartSenal.ChartAreas[0].AxisX.Interval = 1;  // Intervalo de labels en X
            chartSenal.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            // Opcional: Asegurarse de que las etiquetas estén alineadas correctamente
            // chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();

            // Habilitar autoescala en el eje X
            chartSenal.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisX.Maximum = Double.NaN;  // Autoajustar el máximo
            // Habilitar autoescala en el eje Y
            chartSenal.ChartAreas[0].AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisY.Maximum = Double.NaN;  // Autoajustar el máximo
        }



        private void button5_Click(object sender, EventArgs e)
        {
            Graficar2();
        }


        private void Graficar2()
        {
            //Creo la nueva serie de datos.
            _graphSerie = new Series("Muestras");
            _graphSerie.Color = System.Drawing.Color.Green;
            _graphSerie.ChartType = SeriesChartType.Line;  //SeriesChartType.Column; //SeriesChartType.Line;
            _graphSerie.BorderWidth = 1; //2;
            _graphSerie.XValueType = ChartValueType.Single;
            _graphSerie.YValueType = ChartValueType.Single;
            //chartEspectro.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chartEspectro.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            ChartArea chartArea = chartSenal.ChartAreas[0];

            // Configura los valores mínimo y máximo del eje Y
            chartArea.AxisY.Minimum = -0.12;
            chartArea.AxisY.Maximum = 0.5;

            string filePath = @"..\..\CSV\ECG_20Seg_NoFiltrado.txt"; // Ruta al archivo CSV
                                                                     // List<(double, double)> muestras = LoadCsvData(filePath);

            List<(double, double)> dataList = LoadCsvData(filePath);
            Series series = chartSenal.Series["Muestras"];

            //foreach (var (x, y) in dataList)
            //{
            //    series.Points.AddXY(x, -1 * y);
            //}
            //_graphSerie = series;


            // sample audio with tones at 2, 10, and 20 kHz plus white noise
            //double[] signal = FftSharp.SampleData.SampleAudio1();
            double[] signal = new double[16_384];
            for (int i = 0; i < dataList.Count; i++)
            {
                signal[i] = (double)-1 * dataList[i].Item2;
            }


            int sampleRate = 48_000;

            // calculate the power spectral density using FFT
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(signal);
            double[] psd = FftSharp.FFT.Magnitude(spectrum);
            double[] freq = FftSharp.FFT.FrequencyScale(psd.Length, sampleRate);


            int counter = 0;
            foreach (double muestra in psd)
            {
                counter++;
                series.Points.AddXY(counter * 0.0303, muestra); //Calculado 15.2 ms
            }


            //Visuaizacion del eje X
            // Configurar el intervalo del eje X
            chartSenal.ChartAreas[0].AxisX.Interval = 5;  // Intervalo de 1 unidad

            // Configurar el formato de las etiquetas del eje X
            chartSenal.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";  // Mostrar solo números enteros (sin decimales)

            // Opcional: Asegurarse de que las etiquetas estén alineadas correctamente
            // chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();


            //Autoescala
            // Habilitar autoescala en el eje X
            chartSenal.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisX.Maximum = Double.NaN;  // Autoajustar el máximo

            // Habilitar autoescala en el eje Y
            chartSenal.ChartAreas[0].AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisY.Maximum = Double.NaN;  // Autoajustar el máximo
        }

        private void BtnFiltrarSenal_Click(object sender, EventArgs e)
        {
            //Creo la nueva serie de datos.
            //_graphSerie = new Series("Muestras");
            //_graphSerie.Color = System.Drawing.Color.Green;
            //_graphSerie.ChartType = SeriesChartType.Line;  //SeriesChartType.Column; //SeriesChartType.Line;
            //_graphSerie.BorderWidth = 1; //2;
            //_graphSerie.XValueType = ChartValueType.Single;
            //_graphSerie.YValueType = ChartValueType.Single;
            //chartEspectro.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chartEspectro.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            ChartArea chartArea = chartSenalFiltrada.ChartAreas[0];

            // Configura los valores mínimo y máximo del eje Y
            chartArea.AxisY.Minimum = -0.12;
            chartArea.AxisY.Maximum = 0.5;

            Series series = chartSenalFiltrada.Series["Muestras"];

            //foreach (var (x, y) in dataList)
            //{
            //    series.Points.AddXY(x, -1 * y);
            //}
            //_graphSerie = series;


            // sample audio with tones at 2, 10, and 20 kHz plus white noise
            //double[] signal = FftSharp.SampleData.SampleAudio1();
            double[] signal = new double[16_384];
            for (int i = 0; i < _senalECG.Count; i++)
            {
                signal[i] = -1 * _senalECG[i].Item2;
            }

            int sampleRate = 500;
            double[] filtered = FftSharp.Filter.LowPass(signal, sampleRate, maxFrequency: 50);


            int counter = 0;
            for (int i = 0; i < _senalECG.Count; i++)
            {
                counter++;
                series.Points.AddXY(_senalECG[i].Item1, filtered[i]); //Calculado 15.2 ms
            }

            _graphSerie = series;

            //Visuaizacion del eje X
            // Configurar el intervalo del eje X
            chartSenalFiltrada.ChartAreas[0].AxisX.Interval = 10;  // Intervalo de 1 unidad

            // Configurar el formato de las etiquetas del eje X
            chartSenalFiltrada.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";  // Mostrar solo números enteros (sin decimales)

            // Opcional: Asegurarse de que las etiquetas estén alineadas correctamente
            // chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();


            //Autoescala
            // Habilitar autoescala en el eje X
            chartSenalFiltrada.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenalFiltrada.ChartAreas[0].AxisX.Maximum = Double.NaN;  // Autoajustar el máximo

            // Habilitar autoescala en el eje Y
            chartSenalFiltrada.ChartAreas[0].AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenalFiltrada.ChartAreas[0].AxisY.Maximum = Double.NaN;  // Autoajustar el máximo
        }
    }
}
