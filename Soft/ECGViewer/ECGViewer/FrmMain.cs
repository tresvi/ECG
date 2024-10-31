using ClosedXML.Excel;
using ECGViewer.Formularios;
using ECGViewer.Modelos;
using ECGViewer.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        //public const double SPAN = 0.000671;
        //public const double ZERO = -248;
        public const double SPAN = 1;
        public const double ZERO = 0;
        private const string DESCRIPCION_APLICACION = "ECG Viewer 1 Canal";

        private bool _lecturaEnCurso = false;
        private SerialPort _serialPort = new SerialPort();
        private List<Muestra> _senalECG = new List<Muestra>();
        private decimal _tMuestreo;
        private int _fMuestreo;
        private string _archivoActual;


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

                Configuracion config = new Configuracion();
                cmbBaudRate.SelectedIndex = config.BaudRate;
                cmbPuertos.Text = config.PuertoCOM;
                nudTMuestreo.Value = config.TiempoMuestreo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los puertos. Detalles: {ex.Message}", "Iniciando app", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chartSenal_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                GraphicHelpers.InsertarMarcador(chartSenal, e.X, e.Y);
            
            if (e.Button == MouseButtons.Left)
            {
                HitTestResult result = chartSenal.HitTest(e.X, e.Y);

                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    Series serie = chartSenal.Series["Muestras"]; 
                    DataPoint clickedPoint = serie.Points[result.PointIndex];
                    MessageBox.Show($"¡Hiciste clic en el punto (X={clickedPoint.XValue}, Y={clickedPoint.YValues[0]})!");
                }
            }
        }


        private void chartSenal_MouseDown(object sender, MouseEventArgs e)
        {
            if (tsbReglaX.Checked && e.Button == MouseButtons.Left)
            {
                double valorX = chartSenal.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                double valorY = chartSenal.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                lblRegla.Location = new Point(e.X + chartSenal.Location.X + 10, e.Y + chartSenal.Location.Y + 10);
                lblRegla.Visible = true;
            }
        }


        private void chartSenal_MouseMove(object sender, MouseEventArgs e)
        {
            if (tsbReglaX.Checked && e.Button == MouseButtons.Left)
            {
                double inicioSeleccionX = chartSenal.ChartAreas[0].CursorX.SelectionStart;
                double finSeleccionX = chartSenal.ChartAreas[0].CursorX.SelectionEnd;
                double inicioSeleccionY = chartSenal.ChartAreas[0].CursorY.SelectionStart;
                double finSeleccionY = chartSenal.ChartAreas[0].CursorY.SelectionEnd;
                double diferenciaX = Math.Abs(finSeleccionX - inicioSeleccionX);
                double diferenciaY = Math.Abs(finSeleccionY - inicioSeleccionY);

                lblRegla.Text = $"X: {diferenciaX.ToString("0.000")} Seg. \nY: {diferenciaY.ToString("0.000")} mV";
            }
        }
    

        private void chartSenal_MouseUp(object sender, MouseEventArgs e)
        {
            if (tsbReglaX.Checked && e.Button == MouseButtons.Left)
            {
                lblRegla.Visible = false;
                chartSenal.ChartAreas[0].CursorX.SelectionStart = double.NaN;
                chartSenal.ChartAreas[0].CursorX.SelectionEnd = double.NaN;
                chartSenal.ChartAreas[0].CursorY.SelectionStart = double.NaN;
                chartSenal.ChartAreas[0].CursorY.SelectionEnd = double.NaN;
            }
        }


        private void BtnCargarSenal_Click(object sender, EventArgs e)
        {
            string filePath = @"..\..\Archivos_CSV\ECG_20_Seg_NO_FILTRADO.csv"; // Ruta al archivo CSV
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


        private void tsbAbrir_Click(object sender, EventArgs e)
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
                _archivoActual = openFileDialog.FileName;

                if (_senalECG.Count <= 1)
                {
                    MessageBox.Show($"Archivo invalido. El mismo contiene menos de 1 muestra"
                      , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _fMuestreo = (int)Math.Round(1/(_senalECG[1].Tiempo - _senalECG[0].Tiempo));
                GraphicHelpers.CargarGrafico(chartSenal, _senalECG);

                this.Text = $"{DESCRIPCION_APLICACION} | {openFileDialog.FileName}";
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
            GraphicHelpers.ResetZoom(chartSenal, _senalECG);
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
            tsbAbrir.Enabled = false;

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
                timerGraficar.Enabled = true;
                timerGraficar.Start();
                _senalECG = new List<Muestra>();
                _tMuestreo = nudTMuestreo.Value;
                _fMuestreo = (int)Math.Round(1000 / _tMuestreo);
                _contadorMuestras = 0;
                _primerMuestra = true;
                chartSenal.ChartAreas[0].AxisX.Minimum = double.NaN;    //!! TODO: Ver si esto queda
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
               // Debug.WriteLine(data);
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
            tsbAbrir.Enabled = true;
            cmbPuertos.Enabled = true;
            cmbBaudRate.Enabled = true;
            timerPuerto.Enabled = false;
            timerPuerto.Stop();
            timerGraficar.Enabled = false;
            timerGraficar.Stop();
        }


        private void tsbNuevoArchivo_Click(object sender, EventArgs e)
        {

        }


        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            if (_senalECG.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar");
                return;
            } 

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(_archivoActual); 
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
                        string linea = string.Format(CultureInfo.InvariantCulture, "{0},{1}", muestra.Tiempo, muestra.Canal[0]);
                        writer.WriteLine(linea);
                    }
                }

                this.Text = $"{DESCRIPCION_APLICACION} | {saveFileDialog.FileName}";
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
            Settings.Default.PuertoCOM = cmbPuertos.Text;
            Settings.Default.BaudRate= cmbBaudRate.SelectedIndex;
            Settings.Default.TMuestreo = nudTMuestreo.Value;
            Settings.Default.Save();
        }


        bool _primerMuestra = true;
        double _cuentaMax = 0;
        double _cuentaMin = 10000;
        private void timerPuerto_Tick(object sender, EventArgs e)
        {
            chartSenal.ChartAreas[0].AxisX.Minimum = double.NaN;

            if (!_serialPort.IsOpen) return;
            try
            {
                do
                {
                    string data = _serialPort.ReadLine();
                    //Debug.WriteLine(data);

                    if (_primerMuestra)
                    {
                        _primerMuestra = false;
                        continue;
                    }

                    Configuracion config = new Configuracion();
                    Muestra muestra = new Muestra();
                    muestra.Tiempo = _contadorMuestras++ * (double)(_tMuestreo / 1000);

                    double cuenta = double.Parse(data);
                    if (cuenta > _cuentaMax) _cuentaMax = cuenta;
                    if (cuenta < _cuentaMin) _cuentaMin = cuenta;

                    if (config.UsarValoresCrudosADC)
                        muestra.Canal[0] = cuenta;
                    else
                        muestra.Canal[0] = (cuenta + (double)config.Zero) * (double)config.Span;

                    _senalECG.Add(muestra);

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


        private void timerGrafico_Tick(object sender, EventArgs e)
        {
            timerGraficar.Start();
            int muestrasPorGrafico = Settings.Default.MuestrasPorGrafico;
            if (muestrasPorGrafico <= 0) muestrasPorGrafico = 4000;
            try
            {
                GraphicHelpers.ActualizarGrafico(chartSenal, _senalECG, muestrasPorGrafico);
            }
            catch (Exception) { }

            gbSenal.Enabled = true;
            timerGraficar.Start();
        }


        private void tsbExportarATablaC_Click(object sender, EventArgs e)
        {
            if (_senalECG.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }

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
            if (_senalECG.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(_archivoActual);
            saveFileDialog.Filter = "Archivos TXT (*.txt)|*.txt";
            saveFileDialog.Title = "Exportar ECG para File Generator Proteus";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string rutaArchivo = saveFileDialog.FileName;

            try
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    foreach (Muestra muestra in _senalECG)
                    {
                        string linea = string.Format(CultureInfo.InvariantCulture, "{0}\t{1}", muestra.Tiempo, muestra.Canal[0]);
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
            FrmAjustes frmCalibracion = new FrmAjustes();
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


        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            if (_senalECG == null || _senalECG.Count < 1)
            {
                MessageBox.Show("No hay gráfico para imprimir", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmImpresion frmImpresion = new FrmImpresion(chartSenal, _senalECG);
            frmImpresion.ShowDialog();
        }


        private void tsbExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_senalECG.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(_archivoActual);
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
            GraphicHelpers.ModoECG(chartSenal, tsbGridECG.Checked);
        }

        private void tsbImportarDesdeXLSX_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos XLSX (*.xlsx)|*.xlsx";
            openFileDialog.Title = "Seleccionar archivo CSV";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = @"..\..\Archivos_CSV\";

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                _archivoActual = openFileDialog.FileName;
                _senalECG = Utiles.LoadXlsxData(openFileDialog.FileName);
                if (_senalECG.Count <= 1)
                {
                    MessageBox.Show($"Archivo invalido. El mismo contiene menos de 1 muestra"
                      , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _fMuestreo = (int)Math.Round(1 / (_senalECG[1].Tiempo - _senalECG[0].Tiempo));
                GraphicHelpers.CargarGrafico(chartSenal, _senalECG);

                MessageBox.Show($"Archivo importado correctamente. Se importaron {_senalECG.Count} muestras"
                    , "Error al importar" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar archivo de de excel. {ex.Message} \n Stack: {ex.StackTrace}", "Error al exportar"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbReglaX_Click(object sender, EventArgs e)
        {
            chartSenal.ChartAreas[0].AxisX.ScaleView.Zoomable = !tsbReglaX.Checked;
            chartSenal.ChartAreas[0].AxisY.ScaleView.Zoomable = !tsbReglaX.Checked;
            //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            //chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chartSenal.ChartAreas[0].CursorY.IsUserEnabled = tsbReglaX.Checked;
            chartSenal.ChartAreas[0].CursorY.IsUserSelectionEnabled = tsbReglaX.Checked;
        }


    }
}
