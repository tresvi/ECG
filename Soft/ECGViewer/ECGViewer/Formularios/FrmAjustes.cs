using ECGViewer.Modelos;
using ECGViewer.Properties;
using System;
using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmAjustes : Form
    {
        private const string CALIB_NUMBER_FORMAT = "0.00000";

        public FrmAjustes()
        {
            InitializeComponent();

            Configuracion config = new Configuracion();
            nudMuestrasPorGrafico.Value = config.MuestrasPorGrafico;
            nudCalibBitsMin.Value = config.CalibracionBitsMin;
            nudCalibBitsMax.Value = config.CalibracionBitsMax;
            nudCalibValorYMin.Value = config.CalibracionValorYMin;
            nudCalibValorYMax.Value = config.CalibracionValorYMax;
            txtUnidad.Text = config.Unidad;
            chkMuestrasADC.Checked = config.UsarValoresCrudosADC;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            Settings.Default.CalibValorBitsMin = (int) nudCalibBitsMin.Value;
            Settings.Default.CalibValorBitsMax = (int) nudCalibBitsMax.Value;
            Settings.Default.CalibValorYMin = nudCalibValorYMin.Value;
            Settings.Default.CalibValorYMax = nudCalibValorYMax.Value;
            Settings.Default.Unidad = txtUnidad.Text;
            Settings.Default.MuestrasPorGrafico = (int) nudMuestrasPorGrafico.Value;
            Settings.Default.UsarValoresCrudosADC = chkMuestrasADC.Checked;
            Settings.Default.Save();
            this.Close();
        }


        private void chkMuestrasADC_CheckedChanged(object sender, EventArgs e)
        {
            nudCalibBitsMin.Enabled = !chkMuestrasADC.Checked;
            nudCalibBitsMax.Enabled = !chkMuestrasADC.Checked;
            nudCalibValorYMin.Enabled = !chkMuestrasADC.Checked;
            nudCalibValorYMax.Enabled = !chkMuestrasADC.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void nudValorYMin_ValueChanged(object sender, EventArgs e)
        {
            decimal zero = nudCalibValorYMin.Value;
            decimal span = (nudCalibValorYMax.Value - nudCalibValorYMin.Value) / (nudCalibBitsMax.Value - nudCalibBitsMin.Value);
        }

        private void nudValorYMax_ValueChanged(object sender, EventArgs e)
        {
            nudValorYMin_ValueChanged(sender, e);
        }

        private void nudCalibBitsMin_ValueChanged(object sender, EventArgs e)
        {
            nudValorYMin_ValueChanged(sender, e);
        }

        private void nudCalibBitsMax_ValueChanged(object sender, EventArgs e)
        {
            nudValorYMin_ValueChanged(sender, e);
        }

        private void btnResetECGValues_Click(object sender, EventArgs e)
        {
            nudCalibBitsMin.Value = 51;
            nudCalibBitsMax.Value = 969;
            nudCalibValorYMin.Value = -3;
            nudCalibValorYMax.Value = 3;
        }
    }
}
