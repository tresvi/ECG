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
            lblZero.Text = $"ZERO: {config.Zero.ToString(CALIB_NUMBER_FORMAT)}";
            lblSpan.Text = $"SPAN: {config.Span.ToString(CALIB_NUMBER_FORMAT)}";
            nudMuestrasPorGrafico.Value = config.MuestrasPorGrafico;
            nudCalibBitsMin.Value = config.CalibracionBitsMin;
            nudCalibBitsMax.Value = config.CalibracionBitsMax;
            nudValorYMin.Value = config.CalibracionValorYMin;
            nudValorYMax.Value = config.CalibracionValorYMax;
            txtUnidad.Text = config.Unidad;
            chkMuestrasADC.Checked = config.UsarValoresCrudosADC;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            Settings.Default.CalibValorBitsMin = (int) nudCalibBitsMin.Value;
            Settings.Default.CalibValorBitsMax = (int) nudCalibBitsMax.Value;
            Settings.Default.CalibValorYMin = nudValorYMin.Value;
            Settings.Default.CalibValorYMax = nudValorYMax.Value;
            Settings.Default.Unidad = txtUnidad.Text;
            Settings.Default.MuestrasPorGrafico = (int) nudMuestrasPorGrafico.Value;
            Settings.Default.UsarValoresCrudosADC = chkMuestrasADC.Checked;
            Settings.Default.Save();
        }

        private void nudValorYMin_ValueChanged(object sender, EventArgs e)
        {
            Configuracion config = new Configuracion();
            decimal zero = nudValorYMin.Value;
            decimal span = (nudValorYMax.Value - nudValorYMin.Value) / (1023 - 0); 
            lblZero.Text = $"ZERO: {zero.ToString(CALIB_NUMBER_FORMAT)}";
            lblSpan.Text = $"SPAN: {span.ToString(CALIB_NUMBER_FORMAT)}";
        }

        private void nudValorYMax_ValueChanged(object sender, EventArgs e)
        {
            nudValorYMin_ValueChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BtnAplicar_Click(sender, e);
            this.Close();
        }

        private void chkMuestrasADC_CheckedChanged(object sender, EventArgs e)
        {
            nudCalibBitsMin.Enabled = !chkMuestrasADC.Checked;
            nudCalibBitsMax.Enabled = !chkMuestrasADC.Checked;
            nudValorYMin.Enabled = !chkMuestrasADC.Checked;
            nudValorYMax.Enabled = !chkMuestrasADC.Checked;
            lblZero.Text = "Zero: 0";
            lblSpan.Text = "Span: 1";
        }

    }
}
