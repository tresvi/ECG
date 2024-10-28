using ECGViewer.Properties;
using System;
using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmAjustes : Form
    {
        public decimal ValorYMin { get { return Settings.Default.nudValorYMin; }  }
        public decimal ValorYMax { get { return Settings.Default.nudValorYMax; } }
        public string Unidad { get { return Settings.Default.Unidad; } }
        public decimal Span { get { return (ValorYMax - ValorYMin) / (1023 - 0); }}
        public decimal Zero { get { return ValorYMin; }}

        public FrmAjustes()
        {
            InitializeComponent();

            nudValorYMin.Value = ValorYMin;
            nudValorYMax.Value = ValorYMax;
            txtUnidad.Text = Unidad;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            Settings.Default.nudValorYMin = nudValorYMin.Value;
            Settings.Default.nudValorYMax = nudValorYMax.Value;
            Settings.Default.Unidad = txtUnidad.Text;
            Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
