using ECGViewer.Modelos;
using ECGViewer.Properties;
using System;
using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmAjustes : Form
    {

        public FrmAjustes()
        {
            InitializeComponent();

            Configuracion config = new Configuracion();

            nudMuestrasPorGrafico.Value = config.MuestrasPorGrafico;
            nudValorYMin.Value = config.CalibracionValorYMin;
            nudValorYMax.Value = config.CalibracionValorYMax;
            txtUnidad.Text = config.Unidad;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            Settings.Default.CalibValorYMin = nudValorYMin.Value;
            Settings.Default.CalibValorYMax = nudValorYMax.Value;
            Settings.Default.Unidad = txtUnidad.Text;
            Settings.Default.MuestrasPorGrafico = (int) nudMuestrasPorGrafico.Value;
            Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
