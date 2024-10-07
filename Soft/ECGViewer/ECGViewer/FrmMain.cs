using ECGViewer.Formularios;
using ECGViewer.Modelos;
using ECGViewer.Properties;
using FftSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

//TODO: Agregar captura en vivo desde puerto serie
//TODO: Agregar sistema de marcas
//TODO: Agregar guardado de archivo
//TODO: Agregar exportacion a CSV y tabla C++

//https://stackoverflow.com/questions/25801257/c-sharp-line-chart-how-to-create-vertical-line

namespace ECGViewer
{
    public partial class FrmMain : Form
    {
        //private const int FRECUENCIA_MUESTREO = 500;
        private const int FRECUENCIA_CORTE_DFLT = 49;
        const string BAUDRATE_DEFAULT = "9600"; //"19200";
        public const double SPAN = 0.000671;
        public const double ZERO = -248;

        Series _graphSerie;
        private Panel chartPanel;
        private bool _lecturaEnCurso = false;
        private SerialPort _serialPort = new SerialPort();
        private List<Muestra> _senalECG;
        private decimal _tMuestreo;
        private int _fMuestreo;


        public FrmMain()
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
            //chartSenal.ChartAreas[0].AxisX.ScaleView.Size = 50;                   // Cantidad de puntos visibles inicialmente

            // Habilitar el desplazamiento
            chartSenal.ChartAreas[0].AxisX.ScaleView.MinSize = 1;                 // Mínima vista permitida (1 punto)
            chartSenal.ChartAreas[0].AxisX.ScaleView.Position = 0;                // Posición inicial de la vista

            // Configura el comportamiento del scroll
            chartSenal.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 5;         // Tamaño del desplazamiento pequeño (5 puntos)
            chartSenal.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;      // Tamaño mínimo de desplazamiento

            // Opcional: Configurar los intervalos del eje X para hacer la navegación más clara
            chartSenal.ChartAreas[0].AxisX.Interval = 0.5;

            ActivarZoom(chartSenal, true);


            try
            {   
                foreach (String puerto in SerialPort.GetPortNames())
                    cmbPuertos.Items.Add(puerto);

                cmbBaudRate.SelectedIndex = Settings.Default.cmbBaudRateIndex;
                cmbPuertos.Text = Settings.Default.cmbPuertosValue;
                nudTMuestreo.Value = Settings.Default.TMuestreoValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los puertos", "Iniciando app", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private void BtnCargarSenal_Click(object sender, EventArgs e)
        {
            string filePath = @"..\..\Archivos_CSV\ECG_20Seg_NOFiltrado.csv"; // Ruta al archivo CSV
            _senalECG = Utiles.LoadCsvData(filePath);

            for (int i = 0; i < _senalECG.Count; i++)
            {
                double valor2 = 0;//0.04 * Math.Sin(2 * Math.PI * 2 * _senalECG[i].Tiempo);
                double valor1 = 0.04 * Math.Sin(2 * Math.PI * 10 * _senalECG[i].Tiempo);
                double valor3 = 0.02 * Math.Sin(2 * Math.PI * 25 * _senalECG[i].Tiempo);
                double valor4 = 0.02 * Math.Sin(2 * Math.PI * 60 * _senalECG[i].Tiempo);
                _senalECG[i].Canal[0] += valor1 + valor2 + valor3 + valor4;
            }

            _fMuestreo = (int)Math.Round(1 / (_senalECG[1].Tiempo - _senalECG[0].Tiempo));

            //Creo la nueva serie de datos.
            _graphSerie = new Series("Muestras");
            _graphSerie.Color = System.Drawing.Color.AliceBlue;
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

            series.Points.Clear();
            foreach (var muestra in _senalECG)
            {
                series.Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
            }
            _graphSerie = series;

            chartSenal.ChartAreas[0].AxisX.Interval = 0.5;  // Intervalo de labels en X
            chartSenal.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            // Opcional: Asegurarse de que las etiquetas estén alineadas correctamente
            // chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();

            // Habilitar autoescala en el eje X
            chartSenal.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisX.Maximum = Double.NaN;  // Autoajustar el máximo
            // Habilitar autoescala en el eje Y
            chartSenal.ChartAreas[0].AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisY.Maximum = Double.NaN;  // Autoajustar el máximo

            btnFiltrarSenal.Enabled = true;
            btnEspectro.Enabled = true;
            btnFiltrosAvanzados.Enabled = true;

            tsbResetZoom_Click(sender, e);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            // Graficar2();
            PrintDocument printDocument = chartSenal.Printing.PrintDocument;
            printDocument.DefaultPageSettings.Landscape = true;
            chartSenal.Printing.PrintPreview();
        }

        /*
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

            string filePath = @"..\..\Archivos_CSV\ECG_20Seg_NoFiltrado.csv"; // Ruta al archivo CSV
                                                                     // List<(double, double)> muestras = LoadCsvData(filePath);

            List<(double, double)> dataList = LoadCsvData(filePath);
            Series series = chartSenal.Series["Muestras"];

            //foreach (var (x, y) in dataList)
            //{
            //    series.Points.AddXY(x, y);
            //}
            //_graphSerie = series;


            // sample audio with tones at 2, 10, and 20 kHz plus white noise
            //double[] signal = FftSharp.SampleData.SampleAudio1();
            double[] signal = new double[16_384];
            for (int i = 0; i < dataList.Count; i++)
            {
                signal[i] = dataList[i].Item2;
            }
        

            int sampleRate = 500;

            // calculate the power spectral density using FFT
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(signal);
            double[] psd = FftSharp.FFT.Magnitude(spectrum);
            double[] freq = FftSharp.FFT.FrequencyScale(psd.Length, sampleRate);

            for (int i = 0; i < psd.Count(); i++)
            {
                series.Points.AddXY(freq[i], psd[i]); //Calculado 15.2 ms
            }


            //Visuaizacion del eje X
            // Configurar el intervalo del eje X
            chartSenal.ChartAreas[0].AxisX.Interval = 10;  // Intervalo de 1 unidad

            // Configurar el formato de las etiquetas del eje X
            chartSenal.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";  // Mostrar solo números enteros (sin decimales)

            // Opcional: Asegurarse de que las etiquetas estén alineadas correctamente
            // chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();


            //Autoescala
            // Habilitar autoescala en el eje X
            chartSenal.ChartAreas[0].AxisX.Minimum = 0;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisX.Maximum = Double.NaN;  // Autoajustar el máximo

            // Habilitar autoescala en el eje Y
            chartSenal.ChartAreas[0].AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisY.Maximum = Double.NaN;  // Autoajustar el máximo
        }
        */


        private void btnEspectro_Click(object sender, EventArgs e)
        {
            if (_senalECG == null)
            {
                MessageBox.Show("No hay señal cargada", "Ver Espectro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] signal = Utiles.ClonarVectorParaFFT(_senalECG);
            Form form = new FrmEspectro(signal, _fMuestreo);
            form.Show();
        }


        private void BtnFiltro_Click(object sender, EventArgs e)
        {
            FrmConsolaFiltros frmAplicarFiltro = new FrmConsolaFiltros(_senalECG, _fMuestreo);
            frmAplicarFiltro.ShowDialog();
        }


        private void BtnFiltrarSenal_Click(object sender, EventArgs e)
        {
            //Por alguna razon, el valor automatico de los ejes se altera
            double axisYMinimum = chartSenal.ChartAreas[0].AxisY.Minimum;
            double axisYMaximum = chartSenal.ChartAreas[0].AxisY.Maximum;
            double AxisYInterval = chartSenal.ChartAreas[0].AxisY.Interval;

            double[] senal = Utiles.ClonarVectorParaFFT(in _senalECG);
            double[] filtered = Filter.LowPass(senal, _fMuestreo, FRECUENCIA_CORTE_DFLT);

            Series series = chartSenal.Series["Muestras"];
            series.Points.Clear();
            
            for (int i = 0; i < _senalECG.Count; i++)
            {
                _senalECG[i].Canal[0] = filtered[i];
                series.Points.AddXY(_senalECG[i].Tiempo, _senalECG[i].Canal[0]);
            }

            //Por alguna razon, el valor automatico de los ejes se altera
            chartSenal.ChartAreas[0].AxisY.Minimum = axisYMinimum;
            chartSenal.ChartAreas[0].AxisY.Maximum = axisYMaximum;
            chartSenal.ChartAreas[0].AxisY.Interval = AxisYInterval;
        }

        private void tsbAbrirTrx_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv"; // Solo archivos CSV
            openFileDialog.Title = "Seleccionar archivo CSV";
            openFileDialog.Multiselect = false; // Deshabilitar selección múltiple
            openFileDialog.InitialDirectory = @"..\..\Archivos_CSV\";

            try
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                string rutaArchivo = openFileDialog.FileName;
                _senalECG = Utiles.LoadCsvData(rutaArchivo);
                if (_senalECG.Count < 2)
                {
                    MessageBox.Show($"Archivo invalido. El mismo contiene menos de 1 muestra"
                      , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _fMuestreo = (int)Math.Round(1/(_senalECG[1].Tiempo - _senalECG[0].Tiempo));


                //Creo la nueva serie de datos.
                _graphSerie = new Series("Muestras");
                _graphSerie.Color = System.Drawing.Color.AliceBlue;
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

                series.Points.Clear();
                foreach (var muestra in _senalECG)
                {
                    series.Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
                }
                _graphSerie = series;

                chartSenal.ChartAreas[0].AxisX.Interval = 0.5;  // Intervalo de labels en X
                chartSenal.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

                // Opcional: Asegurarse de que las etiquetas estén alineadas correctamente
                // chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();

                // Habilitar autoescala en el eje X
                chartSenal.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Autoajustar el mínimo
                chartSenal.ChartAreas[0].AxisX.Maximum = Double.NaN;  // Autoajustar el máximo
                                                                      // Habilitar autoescala en el eje Y
                chartSenal.ChartAreas[0].AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
                chartSenal.ChartAreas[0].AxisY.Maximum = Double.NaN;  // Autoajustar el máximo

                btnFiltrarSenal.Enabled = true;
                btnEspectro.Enabled = true;
                btnFiltrosAvanzados.Enabled = true;

                tsbResetZoom_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo seleccionado. Detalles: {ex.Message}"
                    , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void tsbResetZoom_Click(object sender, EventArgs e)
        {
            //double maximo = this.chartEspectro.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            //chartEspectro.ChartAreas[0].AxisX.Interval = (int) maximo / 10;
            //ChartUtils.InicializarChart(chartEspectro);
            this.chartSenal.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            this.chartSenal.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void btnIniciarLectura_Click(object sender, EventArgs e)
        {
            if (cmbPuertos.Text == "")
            {
                MessageBox.Show(this, "Debe seleccionar un puerto de comunicacion",
                    "Lectura en curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIniciarLectura.Enabled = false;
            btnFinalizarLectura.Enabled = true;

            try
            {
                cmbPuertos.Enabled = false;
                cmbBaudRate.Enabled = false;
                _serialPort = new SerialPort(cmbPuertos.Text, int.Parse(cmbBaudRate.Text), Parity.None, 8, StopBits.One);
                _serialPort.NewLine = "\n";
               // _serialPort.DataReceived += SerialPort_DataReceived;
                _serialPort.ReadTimeout = 10;
                _serialPort.Open();
                _serialPort.DiscardInBuffer();
                timerPuerto.Enabled = true;
                timerPuerto.Start();
                //tmrGraficar.Enabled = true;
                //tmrGraficar.Start();
                _senalECG = new List<Muestra>();
                _tMuestreo = nudTMuestreo.Value;
                _fMuestreo = (int)Math.Round(1000 / _tMuestreo);
                _contadorMuestras = 0;
                _primerMuestra = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos del puerto serie. Detalles: {ex.Message}"
                    , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        long _contadorMuestras = 0;
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Leer la línea completa (espera hasta recibir el salto de línea)
                string data = _serialPort.ReadLine();
                Debug.WriteLine(data);
                Muestra muestra = new Muestra();
                muestra.Tiempo = _contadorMuestras * (double) (_tMuestreo/1000);
                _contadorMuestras++;
                _senalECG.Add(muestra);
                //Invoke(new MethodInvoker(() =>
                //{
                //    txtLog.Text += '\n' + data;
                //}));
            }
            catch (Exception ex)
            { 
                //MessageBox.Show($"Error al leer datos: {ex.Message}");
                Debug.WriteLine($"ERROR DE LECTURA DE PUERTO {ex.Message}");
            }
        }


        private void btnFinalizarLectura_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen) _serialPort.Close();
            btnIniciarLectura.Enabled = true;
            btnFinalizarLectura.Enabled = false;
            cmbPuertos.Enabled = true;
            cmbBaudRate.Enabled = true;

            timerPuerto.Enabled = false;
            timerPuerto.Stop();
        }


        private void tsbNuevoArchivo_Click(object sender, EventArgs e)
        {

        }


        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            // Crear y configurar el SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Guardar archivo CSV";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            
            string rutaArchivo = saveFileDialog.FileName;

            try
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    foreach (Muestra muestra in _senalECG)
                    {
                        string linea = string.Format(CultureInfo.InvariantCulture, "{0}\t{1}", muestra.Tiempo, -1 * muestra.Canal[0]);
                        writer.WriteLine(linea);
                    }
                }

                MessageBox.Show("Archivo guardado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_serialPort.IsOpen) _serialPort.Close();

            //Guardo la ultima configuracion
            Settings.Default.cmbPuertosValue = cmbPuertos.Text;
            Settings.Default.cmbBaudRateIndex= cmbBaudRate.SelectedIndex;
            Settings.Default.TMuestreoValue = nudTMuestreo.Value;
            Settings.Default.Save();
        }


        bool _graficando = false;
        bool _primerMuestra = true;
        private void timerPuerto_Tick(object sender, EventArgs e)
        {
            if (!_serialPort.IsOpen) return;

            try
            {
                do
                {
                    string data = _serialPort.ReadLine();
                    Debug.WriteLine(data);

                    if (_primerMuestra)
                    {
                        _primerMuestra = false;
                        continue;
                    }
                    
                    Muestra muestra = new Muestra();
                    muestra.Tiempo = _contadorMuestras++ * (double)(_tMuestreo / 1000);
                    muestra.Canal[0] = (double.Parse(data) + ZERO) * SPAN; 
                    _senalECG.Add(muestra);

                    if (_contadorMuestras % 100 == 0)
                        tmrGraficar_Tick(sender, e);
                } while (_serialPort.BytesToRead > 5);
            }
            catch (TimeoutException)
            {
                Debug.WriteLine($"******SERIAL TIMEOUT*******");
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error al leer datos: {ex.Message}");
                Debug.WriteLine($"ERROR DE LECTURA DE PUERTO {ex.Message}");
            }
        }

        private void tmrGraficar_Tick(object sender, EventArgs e)
        {
            //Creo la nueva serie de datos.
            _graphSerie = new Series("Muestras");
            _graphSerie.Color = System.Drawing.Color.AliceBlue;
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

            series.Points.Clear();
            _graficando = true;
            foreach (var muestra in _senalECG)
            {
                series.Points.AddXY(muestra.Tiempo, muestra.Canal[0]);
            }
            _graficando = false;
            _graphSerie = series;

            chartSenal.ChartAreas[0].AxisX.Interval = 0.5;  // Intervalo de labels en X
            chartSenal.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            // Opcional: Asegurarse de que las etiquetas estén alineadas correctamente
            // chartEspectro.ChartAreas[0].AxisX.RoundAxisValues();

            // Habilitar autoescala en el eje X
            chartSenal.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisX.Maximum = Double.NaN;  // Autoajustar el máximo
                                                                  // Habilitar autoescala en el eje Y
            chartSenal.ChartAreas[0].AxisY.Minimum = Double.NaN;  // Autoajustar el mínimo
            chartSenal.ChartAreas[0].AxisY.Maximum = Double.NaN;  // Autoajustar el máximo

            btnFiltrarSenal.Enabled = true;
            btnEspectro.Enabled = true;
            btnFiltrosAvanzados.Enabled = true;

            tsbResetZoom_Click(sender, e);
        }


        private void tsbExportarATablaC_Click(object sender, EventArgs e)
        {
            int indiceMin, indiceMax;

            ChartArea chartArea = chartSenal.ChartAreas[0];
            if (chartArea.AxisX.ScaleView.IsZoomed)
            {
                DialogResult resultado = MessageBox.Show("El gráfico tiene zoom aplicado. Recuerde que " +
                    "la exportación de la señal se realizará en la porción visualizada en pantalla. ¿Desea " +
                   "resetear el zoom para exportar todo el grafico completo?", "Exportacion a tabla"
                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes) tsbResetZoom_Click(sender, e);

                (indiceMin, indiceMax) = Utiles.ObtenerIndicesInicialyFinal(_senalECG
                    , chartArea.AxisX.ScaleView.ViewMinimum
                    , chartArea.AxisX.ScaleView.ViewMaximum);
            }
            else
            {
                indiceMin = 0;
                indiceMax = _senalECG.Count - 1;
            }

            FrmExportarATablaC frmExportarATablaC = new FrmExportarATablaC(_senalECG, indiceMin, indiceMax);
            frmExportarATablaC.ShowDialog();
        }

        private void tsbExportarProteus_Click(object sender, EventArgs e)
        {
            // Crear y configurar el SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Exportar ECG para File Generator Proteus";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string rutaArchivo = saveFileDialog.FileName;

            try
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    foreach (Muestra muestra in _senalECG)
                    {
                        string linea = string.Format(CultureInfo.InvariantCulture, "{0}\t{1}", muestra.Tiempo, -1 * muestra.Canal[0]);
                        writer.WriteLine(linea);
                    }
                }

                MessageBox.Show("Archivo exportado correctamente.", "Exportar a File Generator Proteus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar el archivo: {ex.Message}", "Exportar a File Generator Proteus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbCalibracion_Click(object sender, EventArgs e)
        {
            FrmCalibracion frmCalibracion = new FrmCalibracion();
            frmCalibracion.ShowDialog();
        }
    }
}
