using ECGViewer.Modelos;
using ECGViewer.Models.Dao;
using ECGViewer.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECGViewer.Controllers
{
    internal class MainController
    {
        MainView _view;

        public MainController(MainView view)
        {
            this._view = view;
            _view.tsbAbrir.Click += new EventHandler(OpenFileCSV);
        }


        private void OpenFileCSV(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            openFileDialog.Title = "Seleccionar archivo CSV";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = @"..\..\Archivos_CSV\";

            try
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                string unidad;
                List<StripLineWithComment> anotaciones = new List<StripLineWithComment>();
                MuestraDao muestraDao = new MuestraDao();
                List<Muestra> senalECGTemp = muestraDao.ListFromFile(openFileDialog.FileName, out unidad, out anotaciones);
                

                if (senalECGTemp.Count <= 1)
                {
                    MessageBox.Show($"Archivo invalido. El mismo contiene menos de 1 muestra"
                      , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _view.SenalECG = senalECGTemp;
                _view.ArchivoActual = openFileDialog.FileName;
                _view.FMuestreo = (int)Math.Round(1 / (senalECGTemp[1].Tiempo - senalECGTemp[0].Tiempo));
                _view.AutoEscalaY = true;

                GraphicHelpers.CargarGrafico(_view.chartSenal, _view.SenalECG, _view.AutoEscalaY);
                GraphicHelpers.CargarAnotaciones(_view.chartSenal, anotaciones);
                _view.chartSenal.ChartAreas[0].AxisY.Title = unidad;

                _view.Text = $"{MainView.DESCRIPCION_APLICACION} | {openFileDialog.FileName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo seleccionado. Detalles: {ex.Message}"
                    , "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _view.gbSenal.Enabled = true;
            //TODO: Despues llamar directamente a la funcion desde el controller
            _view.tsbResetZoom_Click(sender, e);



        }


    }
}
