using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ECGViewer.Properties;

namespace ECGViewer.Formularios
{
    public partial class FrmConfiguracionEjes : Form
    {

        private Chart _chart;

        public FrmConfiguracionEjes(ref Chart chart)
        {
            InitializeComponent();
            _chart = chart;
        }


        private void FrmConfiguracionEjes_Load(object sender, EventArgs e)
        {
            chkEscalaAutomatica.Checked = Settings.Default.AutoEscalaY;
            chkEscalaAutomatica_CheckedChanged(sender, e);

            txtUnidad.Text = _chart.ChartAreas[0].AxisY.Title;
            nudYMin.Text = _chart.ChartAreas[0].AxisY.Minimum.ToString();
            nudYMax.Text = _chart.ChartAreas[0].AxisY.Maximum.ToString();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            _chart.ChartAreas[0].AxisY.Title = txtUnidad.Text;

            if (chkEscalaAutomatica.Checked)
            {
                _chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
                _chart.ChartAreas[0].AxisY.Maximum = Double.NaN;
            }
            else
            {
                _chart.ChartAreas[0].AxisY.Minimum = (double) nudYMin.Value;
                _chart.ChartAreas[0].AxisY.Maximum = (double) nudYMax.Value;
            }

            Settings.Default.AutoEscalaY = chkEscalaAutomatica.Checked;
            Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkEscalaAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            nudYMin.Enabled = !chkEscalaAutomatica.Checked;
            nudYMax.Enabled = !chkEscalaAutomatica.Checked;
        }


    }
}
