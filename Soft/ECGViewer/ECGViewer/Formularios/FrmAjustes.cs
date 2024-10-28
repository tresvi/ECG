using ECGViewer.Modelos;
using ECGViewer.Properties;
using System;
using System.Windows.Forms;

namespace ECGViewer.Formularios
{
    public partial class FrmAjustes : Form
    {
        public decimal MuestrasPorGrafico { get { return Settings.Default.MuestrasPorGrafico; } }
        public decimal ValorYMin { get { return Settings.Default.CalibValorYMin; }  }
        public decimal ValorYMax { get { return Settings.Default.CalibValorYMax; } }
        public string Unidad { get { return Settings.Default.Unidad; } }


        public FrmAjustes()
        {
            InitializeComponent();


            nudMuestrasPorGrafico.Value = Settings.Default.MuestrasPorGrafico;
            nudValorYMin.Value = ValorYMin;
            nudValorYMax.Value = ValorYMax;
            txtUnidad.Text = Unidad;
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
