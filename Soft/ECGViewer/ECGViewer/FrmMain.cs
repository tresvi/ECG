using ClosedXML.Excel;
using ECGViewer.Formularios;
using ECGViewer.Modelos;
using ECGViewer.Properties;
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
using Filter = FftSharp.Filter;


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
            GraphicHelpers.InicializarGrafico(chartSenal);

            try
            {   
                foreach (string puerto in SerialPort.GetPortNames())
                    cmbPuertos.Items.Add(puerto);

                cmbBaudRate.SelectedIndex = Settings.Default.cmbBaudRateIndex;
                cmbPuertos.Text = Settings.Default.cmbPuertosValue;
                nudTMuestreo.Value = Settings.Default.TMuestreoValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los puertos. Detalles: {ex.Message}", "Iniciando app", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chartEspectro_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            GraphicHelpers.InsertarMarcador(chartSenal, e.X, e.Y);
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

            GraphicHelpers.CargarGrafico(chartSenal, _senalECG);

            gbSenal.Enabled = true;
            tsbResetZoom_Click(sender, e);
        }


        private void btnEspectro_Click(object sender, EventArgs e)
        {
            if (_senalECG == null)
            {
                MessageBox.Show("No hay señal cargada", "Ver Espectro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] signal = Utiles.ClonarVectorParaFFT(_senalECG);
            Form frmEspectro = new FrmEspectro(signal, _fMuestreo);
            frmEspectro.ShowDialog();
        }


        private void BtnFiltroAvanzados_Click(object sender, EventArgs e)
        {
            double axisYMinimum = chartSenal.ChartAreas[0].AxisY.Minimum;
            double axisYMaximum = chartSenal.ChartAreas[0].AxisY.Maximum;
            double AxisYInterval = chartSenal.ChartAreas[0].AxisY.Interval;

            FrmConsolaFiltros frmAplicarFiltro = new FrmConsolaFiltros(_senalECG, _fMuestreo);
            DialogResult resultado = frmAplicarFiltro.ShowDialog();
            if (resultado != DialogResult.OK) return;

            _senalECG = frmAplicarFiltro.SenalFiltrada;
            GraphicHelpers.CargarGrafico(chartSenal, _senalECG);

            chartSenal.ChartAreas[0].AxisY.Minimum = axisYMinimum;
            chartSenal.ChartAreas[0].AxisY.Maximum = axisYMaximum;
            chartSenal.ChartAreas[0].AxisY.Interval = AxisYInterval;
        }


        private void BtnFiltrarSenal_Click(object sender, EventArgs e)
        {
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

            chartSenal.ChartAreas[0].AxisY.Minimum = axisYMinimum;
            chartSenal.ChartAreas[0].AxisY.Maximum = axisYMaximum;
            chartSenal.ChartAreas[0].AxisY.Interval = AxisYInterval;
        }


        private void tsbAbrirTrx_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            openFileDialog.Title = "Seleccionar archivo CSV";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = @"..\..\Archivos_CSV\";

            try
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                _senalECG = Utiles.LoadCsvData(openFileDialog.FileName);
                if (_senalECG.Count <= 1)
                {
                    MessageBox.Show($"Archivo invalido. El mismo contiene menos de 1 muestra"
                      , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _fMuestreo = (int)Math.Round(1/(_senalECG[1].Tiempo - _senalECG[0].Tiempo));
                GraphicHelpers.CargarGrafico(chartSenal, _senalECG);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo seleccionado. Detalles: {ex.Message}"
                    , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            gbSenal.Enabled = true;
            tsbResetZoom_Click(sender, e);
        }


        private void tsbResetZoom_Click(object sender, EventArgs e)
        {
            GraphicHelpers.ResetZoom(chartSenal);
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
            GraphicHelpers.CargarGrafico(chartSenal, _senalECG);   
            gbSenal.Enabled = true;
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


        private void tsbTijera_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Desea recortar la gráfica al valor mostrado actualmente?", "Recortar grafica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Cancel) return;

            double xMin = chartSenal.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            double xMax = chartSenal.ChartAreas[0].AxisX.ScaleView.ViewMaximum;

            (int indiceMin, int indiceMax) = Utiles.ObtenerIndicesInicialyFinal(_senalECG, xMin, xMax);

            _senalECG = _senalECG.GetRange(indiceMin, indiceMax - indiceMin + 1);
            if (_senalECG.Count == 0) return;

            respuesta = MessageBox.Show("El gráfico se ha cortado exitosamente. Desea establecer a 0 segundos el comienzo del gráfico?"
            , "Recortar gráfico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            Utiles.ResetearTiempo(ref _senalECG);
            GraphicHelpers.CargarGrafico(chartSenal, _senalECG);
            tsbResetZoom_Click(sender, e);
        }

        private void tsbMetricas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no disponible");
        }

        private void tsbAdminMarcadores_Click(object sender, EventArgs e)
        {
            FrmAdministrarMarcadores frmAdminMarcadores = new FrmAdministrarMarcadores(chartSenal);
            frmAdminMarcadores.ShowDialog();
        }


        private PrintDocument printDocument;
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            /*
            PrintDocument printDocument = chartSenal.Printing.PrintDocument;
            
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10); // Márgenes de 10 píxeles en todos los lados

            chartSenal.Printing.PrintPreview();
            */

            // Obtener el documento de impresión del chart


            /*
            PrintDocument printDocument = chartSenal.Printing.PrintDocument;

            // Mostrar la vista previa de impresión
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            //printPreviewDialog.Controls.Clear();
            printPreviewDialog.ShowDialog();
            

            // Después de la vista previa, mostrar el diálogo de selección de impresora
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            // Mostrar el diálogo de impresión
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Si el usuario selecciona una impresora y confirma, procede con la impresión
                printDocument.Print();
            }*/

            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Configurar orientación Landscape
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintChart();
        }



        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener el área de impresión
            Graphics g = e.Graphics;

            // Definir el área de impresión para la parte superior
            int width = e.MarginBounds.Width + 150 ; // Reducir el margen derecho en 50 píxeles
            Rectangle topArea = new Rectangle(0, 0, width, e.MarginBounds.Height / 2);

            // Definir el área de impresión para la parte inferior
            Rectangle bottomArea = new Rectangle(0, e.MarginBounds.Height / 2, width, e.MarginBounds.Height / 2);

            // Obtener el tamaño original del gráfico
            var originalSize = chartSenal.Size;

            chartSenal.ChartAreas[0].AxisX.Title = ""; // Ocultar el título del eje X
            chartSenal.ChartAreas[0].AxisY.Title = ""; // Ocultar el título del eje Y

            // Redimensionar el gráfico para imprimir
            chartSenal.Size = new Size((int)e.MarginBounds.Width, (int)e.MarginBounds.Height);

            // Calcular el punto medio para dividir el gráfico
            int midPoint = chartSenal.Series[0].Points.Count / 2;

            // Crear listas temporales para guardar los puntos de la serie
            var topHalfPoints = new DataPoint[midPoint];
            var bottomHalfPoints = new DataPoint[chartSenal.Series[0].Points.Count - midPoint];

            // Copiar la primera mitad de los puntos
            for (int i = 0; i < midPoint; i++)
            {
                topHalfPoints[i] = chartSenal.Series[0].Points[i];
            }

            // Copiar la segunda mitad de los puntos
            for (int i = midPoint; i < chartSenal.Series[0].Points.Count; i++)
            {
                bottomHalfPoints[i - midPoint] = chartSenal.Series[0].Points[i];
            }

            // Dibujar la parte superior del gráfico
            chartSenal.Series[0].Points.Clear(); // Limpiar los puntos de la serie
            foreach (var point in topHalfPoints)
            {
                chartSenal.Series[0].Points.Add(point); // Agregar cada punto de la mitad superior
            }
            chartSenal.Printing.PrintPaint(g, topArea);

            // Dibujar la parte inferior del gráfico
            chartSenal.Series[0].Points.Clear(); // Limpiar los puntos de la serie
            foreach (var point in bottomHalfPoints)
            {
                chartSenal.Series[0].Points.Add(point); // Agregar cada punto de la mitad inferior
            }
            chartSenal.Printing.PrintPaint(g, bottomArea);

            // Restaurar el tamaño original del gráfico
            chartSenal.Size = originalSize;
        }

        private void PrintChart()
        {
            // Mostrar la vista previa de impresión
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }


        private void tsbExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos XLSX (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Guardar archivo XLSX";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Graficar");
                    worksheet.Cell(1, 1).Value = "Tiempo";
                    worksheet.Cell(1, 2).Value = "Valores";

                    for (int i = 0; i < _senalECG.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = _senalECG[i].Tiempo;
                        worksheet.Cell(i + 2, 2).Value = _senalECG[i].Canal[0];
                    }

                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("El archivo fue creado correctamente", "Exportacion a Excel"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n Stack: {ex.StackTrace}", "Error al exportar"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbGridECG_Click(object sender, EventArgs e)
        {
            //chartSenal.ChartAreas[0].AxisX.MajorGrid.Enabled = tsbGridECG.Checked;
            GraphicHelpers.ModoECG(chartSenal, tsbGridECG.Checked);
        }
    }
}
